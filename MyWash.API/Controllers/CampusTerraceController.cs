using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWash.API.Data;
using MyWash.API.Models;

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
    [Route("status")]
    public async Task<List<CampusTerraceLaundrySession>> GetLaundryMachineStatus()
    {
        var laundrySessions = await applicationDbContext.CampusTerraceLaundrySessions.ToListAsync();
        return laundrySessions;
    }

    [HttpPost]
    [Route("start")]
    public void StartLaundry()
    {

    }

    [HttpPost]
    [Route("stop")]
    public void StopLaundry()
    {

    }


}