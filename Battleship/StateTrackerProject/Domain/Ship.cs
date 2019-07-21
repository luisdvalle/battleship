using System.Collections.Generic;
using System.Linq;
using StateTrackerProject.Enumerations;
using StateTrackerProject.Helpers;
using StateTrackerProject.Interfaces;


namespace StateTrackerProject.Domain
{
    public class Ship : IShip
    {
        public Dictionary<Coordinate, CoordinateState> Coordinates { get; set; }

        public Ship(IEnumerable<Coordinate> coordinates)
        {
            Coordinates = new Dictionary<Coordinate, CoordinateState>(new CoordinateEqualityComparer());

            foreach (var coordinate in coordinates)
            {
                Coordinates.Add(coordinate, CoordinateState.Occupied);
            }
        }

        public bool IsShipSunk()
        {
            var numberCoordinatesHit = Coordinates.Count(s => s.Value == CoordinateState.Hit);

            return numberCoordinatesHit == Coordinates.Count;
        }

        public void TakeHit(Coordinate coordinate)
        {
            if (Coordinates.ContainsKey(coordinate))
            {
                Coordinates[coordinate] = CoordinateState.Hit;
            }
        }
    }
}
