using System;
using FlightBookingSystem.Notifications.Interfaces;

namespace FlightBookingSystem.Notifications
{
    /// <summary>
    /// Sends notifications to the console.
    /// </summary>
    public class ConsoleNotification : INotification
    {
        /// <summary>
        /// Sends a notification message to the console.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}
