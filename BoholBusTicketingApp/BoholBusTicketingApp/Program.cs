using BusTicketingSystem.Hardware;
using BusTicketingSystem.Repositories;
using BusTicketingSystem.Services;
using System;
using System.Windows.Forms;

namespace BoholBusTicketingApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// This is where all DLL components are initialized and registered.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // ============================================
                // 1. INITIALIZE REPOSITORIES (Data Access)
                // ============================================

                IConductorRepository conductorRepository = new ConductorRepository();
                // Demo conductors: C001 (1234), C002 (5678), C003 (9012)

                ITicketRepository ticketRepository = new TicketRepository();
                // Stores all issued tickets

                IRouteRepository routeRepository = new RouteRepository();
                // Routes: A, B, C with locations

                // ============================================
                // 2. INITIALIZE HARDWARE INTERFACE (DLL)
                // ============================================

                IDevice printingMachine = new PrintingMachine();
                // Connects to printer hardware

                // ============================================
                // 3. INITIALIZE MAIN SERVICE (Business Logic)
                // ============================================

                ITicketingService ticketingService = new TicketingService(
                    conductorRepository,      // Conductor data
                    ticketRepository,         // Ticket storage
                    routeRepository,          // Route data
                    printingMachine           // Printer hardware
                );

                // ============================================
                // 4. START APPLICATION WITH LOGIN FORM
                // ============================================

                LoginForm loginForm = new LoginForm();
                Application.Run(loginForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Fatal Error: {ex.Message}\n\nDetails: {ex.StackTrace}",
                    "Application Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
