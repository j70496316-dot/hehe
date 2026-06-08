using System;

namespace BusTicketingSystem
{
    /// <summary>
    /// BusTicketingSystem DLL - Main Class Library
    /// 
    /// USAGE IN YOUR APPLICATION:
    /// 1. Add reference to this DLL in your Windows Forms project
    /// 2. Use the ITicketingService interface for all operations
    /// 3. Initialize the service in your Program.cs or Form load
    /// 
    /// EXAMPLE IN PROGRAM.CS:
    /// 
    ///     using BusTicketingSystem.Repositories;
    ///     using BusTicketingSystem.Services;
    ///     using BusTicketingSystem.Hardware;
    ///     
    ///     static class Program
    ///     {
    ///         [STAThread]
    ///         static void Main()
    ///         {
    ///             Application.EnableVisualStyles();
    ///             
    ///             // Setup
    ///             var conductorRepo = new ConductorRepository();
    ///             var ticketRepo = new TicketRepository();
    ///             var routeRepo = new RouteRepository();
    ///             var printer = new PrintingMachine();
    ///             
    ///             ITicketingService service = new TicketingService(
    ///                 conductorRepo, 
    ///                 ticketRepo, 
    ///                 routeRepo, 
    ///                 printer
    ///             );
    ///             
    ///             LoginForm form = new LoginForm(service);
    ///             Application.Run(form);
    ///         }
    ///     }
    /// 
    /// EXAMPLE IN FORM:
    /// 
    ///     using BusTicketingSystem.Services;
    ///     using BusTicketingSystem.Models;
    ///     
    ///     public partial class LoginForm : Form
    ///     {
    ///         private ITicketingService _service;
    ///         
    ///         public LoginForm(ITicketingService service)
    ///         {
    ///             _service = service;
    ///         }
    ///         
    ///         private void LoginButton_Click(object sender, EventArgs e)
    ///         {
    ///             if (_service.AuthenticateConductor("C001", "1234"))
    ///             {
    ///                 MessageBox.Show("Login successful!");
    ///             }
    ///         }
    ///     }
    /// </summary>
    public static class DllInfo
    {
        public const string Version = "1.0.0";
        public const string Company = "Bohol Bus Ticketing";
        public const string Description = "DLL for Bohol Bus Ticketing System - Printing Machine Integration";
    }
}