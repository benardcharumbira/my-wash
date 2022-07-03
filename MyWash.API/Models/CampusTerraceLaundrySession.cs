using System.ComponentModel.DataAnnotations;

namespace MyWash.API.Models
{
    public class CampusTerraceLaundrySession
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string? UserId { get; set; }
        public User User { get; set; }
        public int CampusTerraceBlockId { get; set; }
        public CampusTerraceBlock CampusTerraceBlock { get; set; }
        public bool WasherStatus { get; set; }
        public bool DryerStatus { get; set; }
    }
}

