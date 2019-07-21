using System;
using StateTrackerProject.Enumerations;
using StateTrackerProject.Interfaces;

namespace StateTrackerProject.Domain
{
    public class Game : IGame
    {
        public IPlayer Player { get; }
        public bool Active { get; set; }
        private readonly IBoard _board;
        private readonly char[] _boardLettersDefinition;

        public Game(string name)
        {
            Player = new Player(name);
            _board = new Board();
            _boardLettersDefinition = _board.BoardLetters;

            Active = false;
        }

        public bool ActivateGame()
        {
            if (Player == null || _board == null)
                return false;

            if (!_board.ActivateBoard())
                return false;

            Active = true;
            return true;
        }

        public bool AddShipToBoard(char x, int y, int length, char orientationCode)
        {
            var initialCoordinate = ConvertToCoordinate(x, y);

            if (initialCoordinate == null)
                return false;

            var shipOrientation = ConvertToShipOrientation(orientationCode);

            return shipOrientation != ShipOrientation.None &&
                   _board.PlaceShip(initialCoordinate, length, shipOrientation);
        }

        public bool AttackCoordinate(char x, int y)
        {
            var attackCoordinate = ConvertToCoordinate(x, y);

            return attackCoordinate != null && _board.AssessAttack(attackCoordinate);
        }

        public int ActiveShips()
        {
            return _board.Ships.Count;
        }

        /// <summary>
        /// Converts an user interface representation of a Coordinate into an internal representation of a Coordinate
        /// </summary>
        /// <param name="x">The X element of the Coordinate represented by a character from 'a' to 'j'</param>
        /// <param name="y">The Y element of the Coordinate represented by a number from 1 to 10</param>
        /// <returns></returns>
        private Coordinate ConvertToCoordinate(char x, int y)
        {
            var xIndex = Array.IndexOf(_boardLettersDefinition, x);

            if (xIndex == -1 || y - 1 > _boardLettersDefinition.Length)
                return null;

            return new Coordinate(xIndex, y - 1);
        }

        /// <summary>
        /// Converts an user interface representation of an Orientation into an internal representation of an
        /// Orientation
        /// </summary>
        /// <param name="shipOrientation">A code representing the orientation of the Ship represented by a one of the
        /// following characters: 'n', 's', 'e' or 'w'</param>
        /// <returns>A ShipOrientation enum</returns>
        private ShipOrientation ConvertToShipOrientation(char shipOrientation)
        {
            switch (shipOrientation)
            {
                case 'n':
                    return ShipOrientation.North;
                case 's':
                    return ShipOrientation.South;
                case 'e':
                    return ShipOrientation.East;
                case 'w':
                    return ShipOrientation.West;
                default:
                    return ShipOrientation.None;
            }
        }
    }
}
