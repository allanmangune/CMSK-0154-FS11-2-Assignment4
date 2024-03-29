using System.Collections.Generic;
using FlightBookingSystem.Enums;

namespace FlightBookingSystem.Entities
{
    /// <summary>
    /// Represents a row of seats on the plane.
    /// </summary>
    public class Row
    {
        /// <summary>
        /// Gets the list of seats in the row.
        /// </summary>
        public List<Seat> Seats { get; private set; } = new List<Seat>();

        /// <summary>
        /// Gets the row number.
        /// </summary>
        public int RowNumber { get; private set; }

        public Row(int rowNumber)
        {
            RowNumber = rowNumber;
            for (int i = 0; i < 4; i++)
            {
                Seats.Add(new Seat((SeatLabel)i, this));
            }
        }
    }
}
