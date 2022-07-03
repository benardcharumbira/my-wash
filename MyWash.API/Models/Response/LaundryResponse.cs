using System;
namespace MyWash.API.Models.Response
{
    public class LaundryResponse
    {
        public bool IsRequestSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public int BlockId { get; set; }
        public bool IsWahingMachine { get; set; }
    }
}

