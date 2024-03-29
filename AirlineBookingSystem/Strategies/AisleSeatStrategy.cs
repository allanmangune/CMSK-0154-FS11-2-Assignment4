using System.Collections.Generic;
using System.Linq;
using FlightBookingSystem.Entities;
using FlightBookingSystem.Enums;

namespace FlightBookingSystem.Strategies
{
    /// <summary>
    /// Represents a seat assignment strategy for passengers preferring aisle seats.
    /// </summary>
    public class AisleSeatStrategy : ISeatAssignmentStrategy
    {
        public bool AssignSeat(Passenger passenger)
        {
            foreach (var row in PlaneConfigurator.Instance.Plane.Rows)
            {
                var aisleSeat = row.Seats.FirstOrDefault(s => (s.Label == SeatLabel.B || s.Label == SeatLabel.C) && s.Status == SeatStatus.Available);
                if (aisleSeat != null)
                {
                    aisleSeat.Status = SeatStatus.Taken;
                    aisleSeat.Passenger = passenger;
                    passenger.Seat = aisleSeat; 
                    return true;
                }
            }
            return false;
        }
    }
}
