using FlightBookingSystem.Notifications.Interfaces;
using FlightBookingSystem.Commands.Interfaces;
using FlightBookingSystem.Strategies;
using FlightBookingSystem.Enums;
using FlightBookingSystem.Entities;
using System;

namespace FlightBookingSystem.Commands
{
    /// <summary>
    /// Command for booking a ticket.
    /// </summary>
    public class BookTicketCommand : ICommand
    {
        private readonly INotification _notification;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookTicketCommand"/> class.
        /// </summary>
        /// <param name="notification">The notification system.</param>
        public BookTicketCommand(INotification notification)
        {
            _notification = notification;
        }

        /// <summary>
        /// Executes the command to book a ticket.
        /// </summary>
        public void Execute()
        {
            // Logic for booking a ticket
            Console.WriteLine("Booking a ticket...");

            // Validate user input for first name and last name
            string firstName = GetValidInput("Please enter your first name: ");
            string lastName = GetValidInput("Please enter your last name: ");

            // Get the seat preference
            SeatPreference seatPreference = GetSeatPreference();

            // Book the ticket
            BookTicket(firstName, lastName, seatPreference);
        }

        /// <summary>
        /// Books a ticket for the passenger.
        /// </summary>
        /// <param name="firstName">The passenger's first name.</param>
        /// <param name="lastName">The passenger's last name.</param>
        /// <param name="seatPreference">The passenger's seat preference.</param>
        private void BookTicket(string firstName, string lastName, SeatPreference seatPreference)
        {
            var passenger = new Passenger
            {
                FirstName = firstName,
                LastName = lastName,
                SeatPreference = seatPreference
            };

            ISeatAssignmentStrategy strategy;
            switch (passenger.SeatPreference)
            {
                case SeatPreference.Window:
                    strategy = new WindowSeatStrategy();
                    break;
                case SeatPreference.Aisle:
                    strategy = new AisleSeatStrategy();
                    break;
                default:
                    strategy = new NoPreferenceSeatStrategy();
                    break;
            }

            bool seatAssigned = strategy.AssignSeat(passenger);
            if (seatAssigned)
            {
                _notification.Send($"Ticket booked successfully. Seat assigned: {passenger.Seat.Label} in row {passenger.Seat.Row.RowNumber}");
            }
            else
            {
                _notification.Send("Sorry, all seats are taken. Please try again later.");
            }
        }

        /// <summary>
        /// Prompts the user for input and ensures that it is not empty.
        /// </summary>
        /// <param name="prompt">The prompt message to display.</param>
        /// <returns>The user input.</returns>
        private string GetValidInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();
            } while (string.IsNullOrWhiteSpace(input) || input.Length == 0); 
            return input;
        }

        /// <summary>
        /// Prompts the user for the seat preference.
        /// </summary>
        /// <returns>The seat preference selected by the user.</returns>
        private SeatPreference GetSeatPreference()
        {
            Console.WriteLine("Please select your seat preference:");
            Console.WriteLine("1. Window");
            Console.WriteLine("2. Aisle");

            while (true)
            {
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(choice))
                {
                    return SeatPreference.None;
                }

                if (choice.Length == 1 && (choice[0] == '1' || choice[0] == '2'))
                {
                    int option = int.Parse(choice);
                    switch (option)
                    {
                        case 1:
                            return SeatPreference.Window;
                        case 2:
                            return SeatPreference.Aisle;
                    }
                }

                Console.WriteLine("Invalid choice. Please enter '1', '2', or leave empty.");
            }
        }
    }
}
