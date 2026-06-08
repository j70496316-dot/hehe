using System;

namespace BusTicketingSystem.Hardware
{
    public interface IDevice
    {
        string IdentifyMe();
        bool IsHardwareAvailable();
        bool PrintTicket(string ticketData);
    }
}