using FlightBookingSystem.Entities;

namespace FlightBookingSystem.Strategies
{
    /// <summary>
    /// Interface for seat assignment strategy.
    /// </summary>
    public interface ISeatAssignmentStrategy
    {
        /// <summary>
        /// Assigns a seat to a passenger based on the strategy.
        /// </summary>
        /// <param name="passenger">The passenger to assign the seat to.</param>
        /// <param name="rows">The list of rows representing the seating arrangement.</param>
        /// <returns>True if a seat was successfully assigned; otherwise, false.</returns>
        bool AssignSeat(Passenger passenger);
    }
}
