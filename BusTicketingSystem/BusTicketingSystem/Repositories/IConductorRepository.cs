using System;
using System.Collections.Generic;
using BusTicketingSystem.Models;

namespace BusTicketingSystem.Repositories
{
    public interface IConductorRepository
    {
        Conductor GetConductorById(string conductorId);
        List<Conductor> GetAllConductors();
        void AddConductor(Conductor conductor);
    }
}