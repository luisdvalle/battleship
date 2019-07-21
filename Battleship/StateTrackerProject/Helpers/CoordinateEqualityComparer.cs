using System.Collections.Generic;
using StateTrackerProject.Domain;

namespace StateTrackerProject.Helpers
{
    /// <summary>
    /// Equality Comparer for a Coordinate to be used when looking up for a Coordinate in a Dictionary
    /// </summary>
    internal class CoordinateEqualityComparer : IEqualityComparer<Coordinate>
    {
        public bool Equals(Coordinate coordinate1, Coordinate coordinate2)
        {
            return string.Equals(coordinate1.Id, coordinate2.Id);
        }

        public int GetHashCode(Coordinate coordinate)
        {
            return coordinate.Id.GetHashCode();
        }
    }
}
