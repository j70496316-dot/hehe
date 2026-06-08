using System;
using System.Collections.Generic;
using BusTicketingSystem.Models;

namespace BusTicketingSystem.Repositories
{
    public interface ITicketRepository
    {
        void AddTicket(Ticket ticket);
        List<Ticket> GetTicketsByDate(DateTime date);
        List<Ticket> GetTicketsByConductorAndDate(string conductorId, DateTime date);
        List<Ticket> GetAllTickets();
    }
}