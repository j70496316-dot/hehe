using System;
using System.Collections.Generic;
using BusTicketingSystem.Models;

namespace BusTicketingSystem.Services
{
    public interface ITicketingService
    {
        bool AuthenticateConductor(string conductorId, string password);
        Conductor GetConductor(string conductorId);
        List<string> GetLocationsByRoute(string routeName);
        double CalculateFare(string routeName, string fromLocation, string toLocation);
        double GetDistance(string routeName, string fromLocation, string toLocation);
        Ticket CreateAndPrintTicket(string conductorId, string routeName, string fromLocation,
            string toLocation, string passengerName);
        List<Ticket> GetTicketsIssuedByDate(DateTime date);
        List<Ticket> GetTicketsIssuedByConductor(string conductorId, DateTime date);
        bool IsHardwareAvailable();
        string GetHardwareStatus();
    }
}