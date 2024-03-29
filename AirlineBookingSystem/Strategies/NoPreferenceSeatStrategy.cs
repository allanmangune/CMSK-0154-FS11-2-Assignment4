using System.Collections.Generic;
using System.Linq;
using FlightBookingSystem.Entities;
using FlightBookingSystem.Enums;

namespace FlightBookingSystem.Strategies
{
    /// <summary>
    /// Represents a seat assignment strategy for passengers with no seating preference.
    /// </summary>
    public class NoPreferenceSeatStrategy : ISeatAssignmentStrategy
    {
        public bool AssignSeat(Passenger passenger)
        {
            foreach (var row in PlaneConfigurator.Instance.Plane.Rows)
            {
                var availableSeat = row.Seats.FirstOrDefault(s => s.Status == SeatStatus.Available);
                if (availableSeat != null)
                {
                    availableSeat.Status = SeatStatus.Taken;
                    availableSeat.Passenger = passenger;
                    passenger.Seat = availableSeat;
                    return true;
                }
            }
            return false;
        }
    }
}
