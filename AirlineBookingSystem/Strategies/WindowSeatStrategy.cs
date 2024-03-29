using System.Collections.Generic;
using System.Linq;
using FlightBookingSystem.Entities;
using FlightBookingSystem.Enums;

namespace FlightBookingSystem.Strategies
{
    /// <summary>
    /// Represents a seat assignment strategy for passengers preferring window seats.
    /// </summary>
    public class WindowSeatStrategy : ISeatAssignmentStrategy
    {
        public bool AssignSeat(Passenger passenger)
        {
            foreach (var row in PlaneConfigurator.Instance.Plane.Rows)
            {
                var windowSeat = row.Seats.FirstOrDefault(s => (s.Label == SeatLabel.A || s.Label == SeatLabel.D) && s.Status == SeatStatus.Available);
                if (windowSeat != null)
                {
                    windowSeat.Status = SeatStatus.Taken;
                    windowSeat.Passenger = passenger;
                    passenger.Seat = windowSeat;
                    return true;
                }
            }
            return false;
        }
    }
}
