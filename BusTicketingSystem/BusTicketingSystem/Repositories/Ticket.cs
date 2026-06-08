using System;

namespace BusTicketingSystem.Models
{
    public class Ticket : BaseModel
    {
        public string ConductorId { get; set; }
        public string Route { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public double Distance { get; set; }
        public double Fare { get; set; }
        public DateTime DateIssued { get; set; }
        public string PassengerName { get; set; }

        public Ticket()
        {
            DateIssued = DateTime.Now;
        }

        public string GetTicketDetails()
        {
            return $"Ticket ID: {ID}\nPassenger: {PassengerName}\nFrom: {FromLocation}\nTo: {ToLocation}\nDistance: {Distance} km\nFare: P{Fare:F2}\nDate: {DateIssued:yyyy-MM-dd HH:mm:ss}";
        }
    }
}