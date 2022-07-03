using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWash.API.Data;
using MyWash.API.Models;
using MyWash.API.Models.Request;
using MyWash.API.Models.Response;

namespace MyWash.API.Controllers;

[ApiController]
[Route("api/[controller]/laundry")]
public class CampusTerraceController : ControllerBase
{
    private readonly ApplicationDbContext applicationDbContext;

    public CampusTerraceController(ApplicationDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    [HttpGet]
    [Route("seed")]
    public async Task<IActionResult> Seed()
    {
        // create blocks
        //var block1 = new CampusTerraceBlock()
        //{
        //    Name = "Block 1"
        //};
        //var block2 = new CampusTerraceBlock()
        //{
        //    Name = "Block 2"
        //};
        //var block3 = new CampusTerraceBlock()
        //{
        //    Name = "Block 3"
        //};

        //await applicationDbContext.CampusTerraceBlocks.AddAsync(block1);
        //await applicationDbContext.CampusTerraceBlocks.AddAsync(block2);
        //await applicationDbContext.CampusTerraceBlocks.AddAsync(block3);

        //await applicationDbContext.SaveChangesAsync();


        // create default laundry sessions
        var laundrySession1 = new CampusTerraceLaundrySession()
        {
            Created = DateTime.Now,
            CampusTerraceBlockId = 1,
            UserId = null,
            WasherStatus = false,
            DryerStatus = false
        };

        var laundrySession2 = new CampusTerraceLaundrySession()
        {
            Created = DateTime.Now,
            CampusTerraceBlockId = 2,
            UserId = null,
            WasherStatus = false,
            DryerStatus = false
        };

        var laundrySession3 = new CampusTerraceLaundrySession()
        {
            Created = DateTime.Now,
            CampusTerraceBlockId = 3,
            UserId = null,
            WasherStatus = false,
            DryerStatus = false
        };

        await applicationDbContext.CampusTerraceLaundrySessions.AddAsync(laundrySession1);
        await applicationDbContext.CampusTerraceLaundrySessions.AddAsync(laundrySession2);
        await applicationDbContext.CampusTerraceLaundrySessions.AddAsync(laundrySession3);

        await applicationDbContext.SaveChangesAsync();


        return Ok();
    }

    [HttpGet]
    [Route("status/{blockId}")]
    public async Task<CampusTerraceLaundrySession> GetLaundryMachineStatus(int blockId)
    {
        var laundrySession = await applicationDbContext.CampusTerraceLaundrySessions
                                        .FirstOrDefaultAsync(x => x.CampusTerraceBlockId == blockId);
        return laundrySession;
    }

    [HttpPost]
    [Route("start")]
    public async Task<LaundryResponse> StartLaundry(LaundryRequest startLaundryRequest)
    {
        var laundrySession = await applicationDbContext.CampusTerraceLaundrySessions
                                        .FirstOrDefaultAsync(x => x.CampusTerraceBlockId == startLaundryRequest.BlockId);

        if (laundrySession != null)
        {
            if (startLaundryRequest.IsWashingMachineTriggered)
            {
                if (!laundrySession.WasherStatus)
                {
                    // book washer session
                    laundrySession.WasherStatus = true;
                    laundrySession.UserId = startLaundryRequest.UserId;

                    await applicationDbContext.SaveChangesAsync();

                    return new LaundryResponse()
                    {
                        IsRequestSuccessful = true,
                        BlockId = startLaundryRequest.BlockId,
                        IsWahingMachine = true,
                        ErrorMessage = null
                    };
                }
                else
                {
                    // return bad request - washer in use
                    return new LaundryResponse()
                    {
                        IsRequestSuccessful = false,
                        BlockId = 0,
                        IsWahingMachine = false,
                        ErrorMessage = "Request failed - machine already in use."
                    };
                }

            }
            else
            {
                if (!laundrySession.DryerStatus)
                {
                    // book dryer session
                    laundrySession.DryerStatus = true;
                    laundrySession.UserId = startLaundryRequest.UserId;

                    await applicationDbContext.SaveChangesAsync();

                    return new LaundryResponse()
                    {
                        IsRequestSuccessful = true,
                        BlockId = startLaundryRequest.BlockId,
                        IsWahingMachine = false,
                        ErrorMessage = null
                    };
                }
                else
                {
                    // return bad request - dryer in use
                    return new LaundryResponse()
                    {
                        IsRequestSuccessful = false,
                        BlockId = 0,
                        IsWahingMachine = false,
                        ErrorMessage = "Request failed - machine already in use."
                    };
                }
            }
        }

        return new LaundryResponse()
        {
            IsRequestSuccessful = false,
            BlockId = 0,
            IsWahingMachine = false,
            ErrorMessage = "Request failed - laundry session not found"
        };
    }

    [HttpPost]
    [Route("stop")]
    public async Task<LaundryResponse> StopLaundry(LaundryRequest stopLaundryRequest)
    {
        var laundrySession = await applicationDbContext.CampusTerraceLaundrySessions
                                .FirstOrDefaultAsync(x =>
                                    x.CampusTerraceBlockId == stopLaundryRequest.BlockId
                                    && x.UserId == stopLaundryRequest.UserId);

        if (laundrySession != null)
        {
            if (stopLaundryRequest.IsWashingMachineTriggered)
            {
                laundrySession.UserId = null;
                laundrySession.WasherStatus = false;
            }
            else
            {
                laundrySession.UserId = null;
                laundrySession.DryerStatus = false;
            }

            await applicationDbContext.SaveChangesAsync();

            return new LaundryResponse()
            {
                IsRequestSuccessful = true,
                BlockId = stopLaundryRequest.BlockId,
                IsWahingMachine = stopLaundryRequest.IsWashingMachineTriggered,
                ErrorMessage = null
            };
        }

        return new LaundryResponse()
        {
            IsRequestSuccessful = false,
            BlockId = 0,
            IsWahingMachine = false,
            ErrorMessage = "Request failed - laundry session not found"
        };
    }
}