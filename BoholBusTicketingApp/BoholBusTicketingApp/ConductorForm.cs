using BusTicketingSystem.Models;
using BusTicketingSystem.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BoholBusTicketingApp
{
    public partial class ConductorForm : Form
    {
        private readonly ITicketingService _service;
        private readonly string _conductorId;
        private readonly Conductor _conductor;

        public ConductorForm(ITicketingService service, string conductorId)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _conductorId = conductorId ?? throw new ArgumentNullException(nameof(conductorId));
            _conductor = _service.GetConductor(conductorId) ?? throw new InvalidOperationException("Conductor not found");
            InitializeComponent();
        }

        private void CalculateFareButton_Click(object sender, EventArgs e)
        {
            if (fromComboBox.SelectedItem == null || toComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select both from and to locations");
                return;
            }

            string fromLocation = fromComboBox.SelectedItem.ToString() ?? "";
            string toLocation = toComboBox.SelectedItem.ToString() ?? "";

            double distance = _service.GetDistance(_conductor.Route, fromLocation, toLocation);
            double fare = _service.CalculateFare(_conductor.Route, fromLocation, toLocation);

            distanceLabel.Text = $"Distance: {distance:F1} km";
            fareLabel.Text = $"Fare: P{fare:F2}";
        }

        private void PrintTicketButton_Click(object sender, EventArgs e)
        {
            if (fromComboBox.SelectedItem == null || toComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select both from and to locations");
                return;
            }

            string passengerName = passengerTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(passengerName))
            {
                MessageBox.Show("Please enter passenger name");
                return;
            }

            string fromLocation = fromComboBox.SelectedItem.ToString() ?? "";
            string toLocation = toComboBox.SelectedItem.ToString() ?? "";

            Ticket? ticket = _service.CreateAndPrintTicket(
                _conductorId,
                _conductor.Route,
                fromLocation,
                toLocation,
                passengerName
            );

            if (ticket != null)
            {
                MessageBox.Show($"Ticket printed successfully!\n\n{ticket.GetTicketDetails()}");
                passengerTextBox.Clear();
                fromComboBox.SelectedIndex = -1;
                toComboBox.SelectedIndex = -1;
            }
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            List<Ticket> tickets = _service.GetTicketsIssuedByConductor(_conductorId, DateTime.Today);

            string message = $"Tickets issued today: {tickets.Count}\n\n";
            double totalFare = 0;
            foreach (Ticket ticket in tickets)
            {
                message += $"{ticket.ID}: {ticket.PassengerName} - P{ticket.Fare:F2}\n";
                totalFare += ticket.Fare;
            }
            message += $"\nTotal Fare: P{totalFare:F2}";

            MessageBox.Show(message, "Daily Inventory");
        }
    }
}
