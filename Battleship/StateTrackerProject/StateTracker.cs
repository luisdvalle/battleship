using StateTrackerProject.Domain;
using StateTrackerProject.Interfaces;

namespace StateTrackerProject
{
    public class StateTracker
    {
        private readonly IGame _game;

        public StateTracker(string name)
        {
            _game = new Game(name);
        }

        public void StartGame()
        {
            _game.ActivateGame();
        }

        public bool AddShipToBoard(char x, int y, int length, char shipOrientation)
        {
            return _game.AddShipToBoard(x, y, length, shipOrientation);
        }

        public bool AssessAttack(char x, int y)
        {
            return _game.AttackCoordinate(x, y);
        }

        public bool HasGameEnded()
        {
            return _game.ActiveShips() < 1;
        }
    }
}
