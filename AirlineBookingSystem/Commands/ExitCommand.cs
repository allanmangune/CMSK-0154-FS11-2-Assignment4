using FlightBookingSystem.Notifications;
using FlightBookingSystem.Notifications.Interfaces;
using FlightBookingSystem.Commands.Interfaces;
using System;

namespace FlightBookingSystem.Commands
{
    /// <summary>
    /// Command for exiting the application.
    /// </summary>
    public class ExitCommand : ICommand
    {
        private readonly INotification _notification;

        public ExitCommand(INotification notification)
        {
            _notification = notification;
        }

        public void Execute()
        {
            Console.WriteLine("Exiting the application...");
            _notification.Send("Goodbye!");
            Environment.Exit(0);
        }
    }
}
