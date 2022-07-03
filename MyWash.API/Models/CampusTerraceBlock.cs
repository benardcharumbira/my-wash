using System.ComponentModel.DataAnnotations;

namespace MyWash.API.Models
{
    public class CampusTerraceBlock
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}