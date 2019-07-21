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
    }
}
