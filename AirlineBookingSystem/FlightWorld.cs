using System;
using FlightBookingSystem.Commands;
using FlightBookingSystem.Notifications;
using FlightBookingSystem.Notifications.Interfaces;

namespace FlightBookingSystem
{
    /// <summary>
    /// Represents the main control of the flight booking system.
    /// </summary>
    public class FlightWorld
    {
        private readonly INotification _notification;

        public FlightWorld()
        {
            PlaneConfigurator configurator = PlaneConfigurator.Instance;
            _notification = new ConsoleNotification();
        }

        /// <summary>
        /// Starts the flight booking system.
        /// </summary>
        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("");
                Console.WriteLine("Select the number of the option you want to select:");
                Console.WriteLine("1. Book a ticket\n2. See seating chart\n3. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        var bookCommand = new BookTicketCommand(_notification);
                        bookCommand.Execute();
                        break;
                    case "2":
                        var viewCommand = new ViewSeatingChartCommand(_notification);
                        viewCommand.Execute();
                        break;
                    case "3":
                        var exitCommand = new ExitCommand(_notification);
                        exitCommand.Execute();
                        break;
                    default:
                        _notification.Send("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}
