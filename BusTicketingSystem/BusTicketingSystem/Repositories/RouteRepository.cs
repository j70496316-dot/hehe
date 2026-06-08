using System;
using System.Collections.Generic;
using System.Linq;
using BusTicketingSystem.Models;

namespace BusTicketingSystem.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private List<Route> _routes;

        public RouteRepository()
        {
            _routes = new List<Route>();
            InitializeRoutes();
        }

        private void InitializeRoutes()
        {
            // Route A
            Route routeA = new Route("Route A");
            routeA.AddLocation("Terminal", 0);
            routeA.AddLocation("Poblacion", 5);
            routeA.AddLocation("San Jose", 10);
            routeA.AddLocation("Tagbilaran", 15);
            _routes.Add(routeA);

            // Route B
            Route routeB = new Route("Route B");
            routeB.AddLocation("Terminal", 0);
            routeB.AddLocation("Buenavista", 8);
            routeB.AddLocation("Mansasa", 12);
            routeB.AddLocation("Corella", 18);
            _routes.Add(routeB);

            // Route C
            Route routeC = new Route("Route C");
            routeC.AddLocation("Terminal", 0);
            routeC.AddLocation("Loon", 7);
            routeC.AddLocation("Antequera", 14);
            routeC.AddLocation("Panglao", 20);
            _routes.Add(routeC);
        }

        public Route GetRouteByName(string routeName)
        {
            return _routes.FirstOrDefault(r => r.Name == routeName);
        }

        public List<Route> GetAllRoutes()
        {
            return _routes;
        }

        public void AddRoute(Route route)
        {
            _routes.Add(route);
        }
    }
}