namespace FlightBookingSystem.Notifications.Interfaces
{
    /// <summary>
    /// Interface for sending notifications.
    /// </summary>
    public interface INotification
    {
        /// <summary>
        /// Sends a notification message.
        /// </summary>
        /// <param name="message">The message to send.</param>
        void Send(string message);
    }
}
