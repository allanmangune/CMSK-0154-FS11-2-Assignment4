using FlightBookingSystem.Notifications.Interfaces;
using FlightBookingSystem.Commands.Interfaces;
using System;
using FlightBookingSystem.Enums;

namespace FlightBookingSystem.Commands
{
    /// <summary>
    /// Command for viewing the seating chart.
    /// </summary>
    public class ViewSeatingChartCommand : ICommand
    {
        private readonly INotification _notification;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewSeatingChartCommand"/> class.
        /// </summary>
        /// <param name="notification">The notification system.</param>
        public ViewSeatingChartCommand(INotification notification)
        {
            _notification = notification;
        }

        /// <summary>
        /// Executes the command to view the seating chart.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Viewing seating chart...");
            string seatingChart = GetSeatingChart();
            _notification.Send(seatingChart);
        }

        /// <summary>
        /// Gets the current seating chart.
        /// </summary>
        /// <returns>The seating chart.</returns>
        private string GetSeatingChart()
        {
            string seatingChart = "Seating Chart:\n";
            foreach (var row in PlaneConfigurator.Instance.Plane.Rows)
            {
                string rowLabel = row.RowNumber.ToString().PadLeft(2) + " ";
                string rowSeats = string.Join(" ", row.Seats.Select(seat =>
                {
                    if (seat.Status == SeatStatus.Taken)
                    {
                        string firstNameInitial = string.IsNullOrEmpty(seat.Passenger?.FirstName) ? " " : seat.Passenger.FirstName[0].ToString();
                        string lastNameInitial = string.IsNullOrEmpty(seat.Passenger?.LastName) ? " " : seat.Passenger.LastName[0].ToString();
                        return firstNameInitial + lastNameInitial;
                    }
                    else
                    {
                        return seat.Label.ToString();
                    }
                }));

                seatingChart += rowLabel + rowSeats + "\n";
            }

            return seatingChart;
        }
    }
}
