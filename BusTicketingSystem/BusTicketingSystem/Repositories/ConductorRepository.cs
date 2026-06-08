using System;
using System.Collections.Generic;
using System.Linq;
using BusTicketingSystem.Models;

namespace BusTicketingSystem.Repositories
{
    public class ConductorRepository : IConductorRepository
    {
        private List<Conductor> _conductors;

        public ConductorRepository()
        {
            _conductors = new List<Conductor>
            {
                new Conductor { ID = "C001", Name = "Juan Dela Cruz", Route = "Route A", Password = "1234" },
                new Conductor { ID = "C002", Name = "Maria Santos", Route = "Route B", Password = "5678" },
                new Conductor { ID = "C003", Name = "Antonio Lopez", Route = "Route C", Password = "9012" }
            };
        }

        public Conductor GetConductorById(string conductorId)
        {
            return _conductors.FirstOrDefault(c => c.ID == conductorId);
        }

        public List<Conductor> GetAllConductors()
        {
            return _conductors;
        }

        public void AddConductor(Conductor conductor)
        {
            _conductors.Add(conductor);
        }
    }
}