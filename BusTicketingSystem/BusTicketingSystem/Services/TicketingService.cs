using System;
using System.Collections.Generic;
using System.Linq;
//using System.Windows.Forms;
using BusTicketingSystem.Models;
using BusTicketingSystem.Hardware;
using BusTicketingSystem.Repositories;

namespace BusTicketingSystem.Services
{
    public class TicketingService : ITicketingService
    {
        private readonly IConductorRepository _conductorRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly IDevice _printingMachine;
        private readonly double _farePerKm = 15.0;

        public TicketingService(IConductorRepository conductorRepository, ITicketRepository ticketRepository,
            IRouteRepository routeRepository, IDevice printingMachine)
        {
            _conductorRepository = conductorRepository;
            _ticketRepository = ticketRepository;
            _routeRepository = routeRepository;
            _printingMachine = printingMachine;
        }

        public bool AuthenticateConductor(string conductorId, string password)
        {
            Conductor conductor = _conductorRepository.GetConductorById(conductorId);
            if (conductor != null && conductor.Password == password)
            {
                return true;
            }
            return false;
        }

        public Conductor GetConductor(string conductorId)
        {
            return _conductorRepository.GetConductorById(conductorId);
        }

        public List<string> GetLocationsByRoute(string routeName)
        {
            Route route = _routeRepository.GetRouteByName(routeName);
            if (route != null)
            {
                return route.Locations.Keys.ToList();
            }
            return new List<string>();
        }

        public double CalculateFare(string routeName, string fromLocation, string toLocation)
        {
            double distance = GetDistance(routeName, fromLocation, toLocation);
            return distance * _farePerKm;
        }

        public double GetDistance(string routeName, string fromLocation, string toLocation)
        {
            Route route = _routeRepository.GetRouteByName(routeName);
            if (route != null)
            {
                return route.GetDistance(fromLocation, toLocation);
            }
            return 0;
        }

        public Ticket CreateAndPrintTicket(string conductorId, string routeName,
            string fromLocation, string toLocation, string passengerName)
        {
            try
            {
                // Check hardware
                if (!_printingMachine.IsHardwareAvailable())
                {
                    throw new Exception("ERROR: Printing Machine is OFFLINE!");
                 
                }

                // Get conductor
                Conductor conductor = GetConductor(conductorId);
                if (conductor == null)
                {
                    throw new Exception("Conductor not found!");
             
                }

                // Calculate distance and fare
                double distance = GetDistance(routeName, fromLocation, toLocation);
                double fare = CalculateFare(routeName, fromLocation, toLocation);

                // Create ticket
                string ticketId = "TKT" + DateTime.Now.ToString("yyyyMMddHHmmss") + conductorId;
                Ticket ticket = new Ticket
                {
                    ID = ticketId,
                    ConductorId = conductorId,
                    Route = routeName,
                    FromLocation = fromLocation,
                    ToLocation = toLocation,
                    Distance = distance,
                    Fare = fare,
                    PassengerName = passengerName,
                    DateIssued = DateTime.Now
                };

                // Print ticket
                string ticketData = $"===== BOHOL BUS TICKET =====\n" +
                    $"Ticket ID: {ticket.ID}\n" +
                    $"Conductor: {conductor.Name}\n" +
                    $"Route: {routeName}\n" +
                    $"Passenger: {passengerName}\n" +
                    $"From: {fromLocation}\n" +
                    $"To: {toLocation}\n" +
                    $"Distance: {distance:F1} km\n" +
                    $"Fare: P{fare:F2}\n" +
                    $"Date & Time: {ticket.DateIssued:yyyy-MM-dd HH:mm:ss}\n" +
                    $"=============================";

                if (_printingMachine.PrintTicket(ticketData))
                {
                    _ticketRepository.AddTicket(ticket);
                    return ticket;
                }
                else
                {
                    throw new Exception("Failed to print ticket!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating ticket: " + ex.Message);
            }
        }

        public List<Ticket> GetTicketsIssuedByDate(DateTime date)
        {
            return _ticketRepository.GetTicketsByDate(date);
        }

        public List<Ticket> GetTicketsIssuedByConductor(string conductorId, DateTime date)
        {
            return _ticketRepository.GetTicketsByConductorAndDate(conductorId, date);
        }

        public bool IsHardwareAvailable()
        {
            return _printingMachine.IsHardwareAvailable();
        }

        public string GetHardwareStatus()
        {
            return _printingMachine.IsHardwareAvailable() ? "ONLINE" : "OFFLINE";
        }
    }
}