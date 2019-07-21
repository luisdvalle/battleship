using System.Collections.Generic;
using StateTrackerProject.Domain;
using StateTrackerProject.Enumerations;
using Xunit;

namespace StateTrackerTests
{
    public class ShipTests
    {
        [Fact]
        public void TakeHit_WhenValidCoordinateGiven_SetsCoordinateAsHit()
        {
            var coordinates = new List<Coordinate>
            {
                new Coordinate(0, 1),
                new Coordinate(0, 2),
                new Coordinate(0, 3)
            };
            var ship = new Ship(coordinates);

            ship.TakeHit(new Coordinate(0, 1));

            Assert.Equal(CoordinateState.Hit, ship.Coordinates[new Coordinate(0, 1)]);
        }
    }
}
