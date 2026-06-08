using System;

namespace BusTicketingSystem.Models
{
    public class Conductor : BaseModel
    {
        public string Name { get; set; }
        public string Route { get; set; }
        public string Password { get; set; }
    }
}