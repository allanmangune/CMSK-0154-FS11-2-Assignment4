using System;
using System.Collections.Generic;
using FlightBookingSystem.Enums;
using FlightBookingSystem.Entities;

namespace FlightBookingSystem
{
    /// <summary>
    /// Singleton class responsible for configuring the plane and providing access to the configured plane instance.
    /// </summary>
    public class PlaneConfigurator
    {
        private static PlaneConfigurator _instance;
        private readonly Plane _plane;

        /// <summary>
        /// Private constructor to prevent external instantiation.
        /// </summary>
        private PlaneConfigurator()
        {
            _plane = InitializePlane();
        }

        /// <summary>
        /// Gets the singleton instance of the PlaneConfigurator.
        /// </summary>
        public static PlaneConfigurator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlaneConfigurator();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Gets the configured plane instance.
        /// </summary>
        public Plane Plane => _plane;

        /// <summary>
        /// Initializes and configures the plane instance.
        /// </summary>
        /// <returns>The initialized plane instance.</returns>
        private Plane InitializePlane()
        {
            Plane plane = new Plane();
            InitializeRows(plane);
            return plane;
        }

        /// <summary>
        /// Initializes the rows of the plane.
        /// </summary>
        /// <param name="plane">The plane instance to initialize rows for.</param>
        private void InitializeRows(Plane plane)
        {
            const int rowCount = 12;
            for (int i = 1; i <= rowCount; i++)
            {
                Row row = new Row(i);
                plane.AddRow(row);
            }
        }
    }
}
