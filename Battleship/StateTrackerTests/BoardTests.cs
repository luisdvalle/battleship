using StateTrackerProject.Domain;
using StateTrackerProject.Enumerations;
using Xunit;

namespace StateTrackerTests
{
    public class BoardTests
    {
        [Fact]
        public void ActivateBoard_WhenValidInputIsGiven_ReturnsActiveBoard()
        {
            var board = new Board();

            board.ActivateBoard();

            Assert.Equal(ModelState.Active, board.State);
            Assert.Equal(100, board.Coordinates.Length);
        }

        [Theory]
        [InlineData(0, 0, 3, ShipOrientation.East)]
        [InlineData(2, 3, 2, ShipOrientation.North)]
        [InlineData(3, 2, 4, ShipOrientation.West)]
        [InlineData(4, 2, 3, ShipOrientation.South)]
        public void PlaceShip_WhenValidCoordinatesGiven_ReturnsShip(int x, int y, int length,
            ShipOrientation shipOrientation)
        {
            var board = new Board();
            board.ActivateBoard();
            var initialCoordinate = new Coordinate(x, y);

            var added = board.PlaceShip(initialCoordinate, length, shipOrientation);

            Assert.True(added);
            Assert.Equal(length, board.Ships[0].Coordinates.Count);
        }

        [Theory]
        [InlineData(0, 0, 11, ShipOrientation.East)]
        [InlineData(2, 3, 8, ShipOrientation.North)]
        [InlineData(3, 2, 5, ShipOrientation.West)]
        [InlineData(4, 2, 4, ShipOrientation.South)]
        public void PlaceShip_WhenNonValidCoordinatesGiven_ReturnsNull(int x, int y, int length,
            ShipOrientation shipOrientation)
        {
            var board = new Board();
            board.ActivateBoard();
            var initialCoordinate = new Coordinate(x, y);

            var added = board.PlaceShip(initialCoordinate, length, shipOrientation);

            Assert.False(added);
            Assert.Empty(board.Ships);
        }
    }
}
