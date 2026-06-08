using System;
using System.Collections.Generic;

namespace BusTicketingSystem.Models
{
    public class Route
    {
        public string Name { get; set; }
        public Dictionary<string, double> Locations { get; set; }

        public Route()
        {
            Locations = new Dictionary<string, double>();
        }

        public Route(string name)
        {
            Name = name;
            Locations = new Dictionary<string, double>();
        }

        public void AddLocation(string location, double kmFromStart)
        {
            Locations[location] = kmFromStart;
        }

        public double GetDistance(string fromLocation, string toLocation)
        {
            if (Locations.ContainsKey(fromLocation) && Locations.ContainsKey(toLocation))
            {
                return Math.Abs(Locations[toLocation] - Locations[fromLocation]);
            }
            return 0;
        }
    }
}