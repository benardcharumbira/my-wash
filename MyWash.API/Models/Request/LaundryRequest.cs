using System;
namespace MyWash.API.Models.Request
{
    public class LaundryRequest
    {
        public string? UserId { get; set; }
        public int BlockId { get; set; }
        public bool IsWashingMachineTriggered { get; set; }
    }
}

