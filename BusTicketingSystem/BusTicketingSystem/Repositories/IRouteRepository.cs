using System;
using System.Collections.Generic;
using BusTicketingSystem.Models;

namespace BusTicketingSystem.Repositories
{
    public interface IRouteRepository
    {
        Route GetRouteByName(string routeName);
        List<Route> GetAllRoutes();
        void AddRoute(Route route);
    }
}