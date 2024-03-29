using FlightBookingSystem.Enums;

namespace FlightBookingSystem.Entities
{
    /// <summary>
    /// Represents an individual seat on the plane.
    /// </summary>
    public class Seat
    {
        /// <summary>
        /// Gets the label of the seat (A, B, C, D).
        /// </summary>
        public SeatLabel Label { get; private set; }

        /// <summary>
        /// Gets or sets the status of the seat (available or taken).
        /// </summary>
        public SeatStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the passenger assigned to the seat.
        /// </summary>
        public Passenger Passenger { get; set; } 

        /// <summary>
        /// Gets the row to which the seat belongs.
        /// </summary>
        public Row Row { get; set; } 

        public Seat(SeatLabel label, Row row)
        {
            Label = label;
            Status = SeatStatus.Available;
            Row = row;
        }
    }
}
