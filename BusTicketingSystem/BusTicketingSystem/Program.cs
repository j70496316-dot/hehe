using BusTicketingSystem.Hardware;
using BusTicketingSystem.Repositories;
using BusTicketingSystem.Services;
using System;
using static System.Net.Mime.MediaTypeNames;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Create DLL instances
        var conductorRepo = new ConductorRepository();
        var ticketRepo = new TicketRepository();
        var routeRepo = new RouteRepository();
        var printer = new PrintingMachine();

        // Create service
        ITicketingService service = new TicketingService(
            conductorRepo,
            ticketRepo,
            routeRepo,
            printer
        );

        // Pass to your form
        Form1 form = new Form1(service);
        Application.Run(form);
    }
}