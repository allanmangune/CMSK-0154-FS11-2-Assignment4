using System.Collections.Generic;

namespace FlightBookingSystem.Entities
{
    /// <summary>
    /// Represents a plane with rows of seats.
    /// </summary>
    public class Plane
    {
        private List<Row> _rows;

        /// <summary>
        /// Gets the rows of seats in the plane.
        /// </summary>
        public List<Row> Rows => _rows;

        /// <summary>
        /// Initializes a new instance of the <see cref="Plane"/> class.
        /// </summary>
        public Plane()
        {
            _rows = new List<Row>();
        }

        /// <summary>
        /// Adds a row to the plane.
        /// </summary>
        /// <param name="row">The row to add.</param>
        public void AddRow(Row row)
        {
            _rows.Add(row);
        }

        /// <summary>
        /// Removes a row from the plane.
        /// </summary>
        /// <param name="row">The row to remove.</param>
        public void RemoveRow(Row row)
        {
            _rows.Remove(row);
        }

        /// <summary>
        /// Clears all rows from the plane.
        /// </summary>
        public void ClearRows()
        {
            _rows.Clear();
        }
    }
}
