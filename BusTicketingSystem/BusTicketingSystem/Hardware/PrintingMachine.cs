using System;
using System.Diagnostics;

namespace BusTicketingSystem.Hardware
{
    public class PrintingMachine : IDevice
    {
        private bool _isHardwareAvailable = false;
        private int _ticketsPrinted = 0;

        public PrintingMachine()
        {
            CheckHardware();
        }

        public string IdentifyMe()
        {
            return "Printing Machine - BOHOL BUS TICKETING SYSTEM - ID: 6789";
        }

        public bool IsHardwareAvailable()
        {
            return _isHardwareAvailable;
        }

        public bool PrintTicket(string ticketData)
        {
            try
            {
                if (!_isHardwareAvailable)
                {
                    return false;
                }

                // Simulate printing ticket
                Debug.WriteLine("========== PRINTING TICKET ==========");
                Debug.WriteLine(ticketData);
                Debug.WriteLine("====================================");

                _ticketsPrinted++;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int GetTicketsPrinted()
        {
            return _ticketsPrinted;
        }

        public void ResetCounter()
        {
            _ticketsPrinted = 0;
        }

        private void CheckHardware()
        {
            // Check if printing hardware is available
            // For simulation, set to true
            // In production, connect to actual hardware
            _isHardwareAvailable = true;
        }
    }
}