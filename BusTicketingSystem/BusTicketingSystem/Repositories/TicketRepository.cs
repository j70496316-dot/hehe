using System;
using System.Collections.Generic;
using System.Linq;
using BusTicketingSystem.Models;

namespace BusTicketingSystem.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private List<Ticket> _tickets;

        public TicketRepository()
        {
            _tickets = new List<Ticket>();
        }

        public void AddTicket(Ticket ticket)
        {
            _tickets.Add(ticket);
        }

        public List<Ticket> GetTicketsByDate(DateTime date)
        {
            return _tickets.Where(t => t.DateIssued.Date == date.Date).ToList();
        }

        public List<Ticket> GetTicketsByConductorAndDate(string conductorId, DateTime date)
        {
            return _tickets.Where(t => t.ConductorId == conductorId && t.DateIssued.Date == date.Date).ToList();
        }

        public List<Ticket> GetAllTickets()
        {
            return _tickets;
        }
    }
}