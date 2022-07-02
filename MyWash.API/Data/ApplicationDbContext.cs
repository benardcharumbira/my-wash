using Microsoft.EntityFrameworkCore;
using MyWash.API.Models;

namespace MyWash.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
            
    }
    public DbSet<CampusTerraceBlock> CampusTerraceBlocks { get; set; }
    public DbSet<CampusTerraceLaundrySession> CampusTerraceLaundrySessions { get; set; }
}