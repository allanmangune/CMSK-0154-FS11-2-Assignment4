namespace FlightBookingSystem
{
    /// <summary>
    /// Entry point of the flight booking system application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method, the entry point of the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            FlightWorld world = new FlightWorld();
            world.Run();
        }
    }
}
