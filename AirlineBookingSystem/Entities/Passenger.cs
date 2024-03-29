using FlightBookingSystem.Enums;

namespace FlightBookingSystem.Entities
{
    /// <summary>
    /// Represents a passenger with personal information and seating preference.
    /// </summary>
    public class Passenger
    {
        /// <summary>
        /// Gets or sets the first name of the passenger.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the passenger.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the seating preference of the passenger.
        /// </summary>
        public SeatPreference SeatPreference { get; set; }

        /// <summary>
        /// Gets or sets the assigned seat of the passenger.
        /// </summary>
        public Seat Seat { get; set; }
    }
}
