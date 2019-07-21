using StateTrackerProject.Domain;
using Xunit;

namespace StateTrackerTests
{
    public class GameTests
    {
        [Fact]
        public void CreateGame_WhenValidPlayerAndBoardGiven_ReturnsActiveGame()
        {
            var game = new Game("John Doe");

            game.ActivateGame();

            Assert.True(game.Active);
        }
    }
}
