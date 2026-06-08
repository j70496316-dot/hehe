using BusTicketingSystem.Models;
using BusTicketingSystem.Services;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;

public partial class AdminForm : Form
{
    private ITicketingService _service;

    public AdminForm(ITicketingService service)
    {
        _service = service;
        InitializeComponent();
    }

    private void ViewReportButton_Click(object sender, EventArgs e)
    {
        DateTime selectedDate = datePicker.Value.Date;
        List<Ticket> tickets = _service.GetTicketsIssuedByDate(selectedDate);

        dataGridView1.Rows.Clear();

        double totalFare = 0;
        foreach (Ticket ticket in tickets)
        {
            dataGridView1.Rows.Add(
                ticket.ID,
                ticket.ConductorId,
                ticket.Route,
                ticket.PassengerName,
                ticket.FromLocation,
                ticket.ToLocation,
                $"P{ticket.Fare:F2}",
                ticket.DateIssued.ToString("yyyy-MM-dd HH:mm:ss")
            );
            totalFare += ticket.Fare;
        }

        MessageBox.Show($"Date: {selectedDate:yyyy-MM-dd}\nTotal Tickets: {tickets.Count}\nTotal Fare: P{totalFare:F2}");
    }
}