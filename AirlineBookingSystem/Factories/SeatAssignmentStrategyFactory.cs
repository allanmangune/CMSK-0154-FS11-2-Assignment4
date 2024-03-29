using FlightBookingSystem.Enums;
using FlightBookingSystem.Strategies;

namespace FlightBookingSystem.Factories
{
    /// <summary>
    /// Factory class for creating seat assignment strategies.
    /// </summary>
    public static class SeatAssignmentStrategyFactory
    {
        /// <summary>
        /// Gets the appropriate seat assignment strategy based on the passenger's preference.
        /// </summary>
        /// <param name="preference">The passenger's seat preference.</param>
        /// <returns>An instance of the seat assignment strategy.</returns>
        public static ISeatAssignmentStrategy GetStrategy(SeatPreference preference)
        {
            return preference switch
            {
                SeatPreference.Window => new WindowSeatStrategy(),
                SeatPreference.Aisle => new AisleSeatStrategy(),
                _ => new NoPreferenceSeatStrategy(),
            };
        }
    }
}
