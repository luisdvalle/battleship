using System.Collections.Generic;
using System.Linq;
using StateTrackerProject.Enumerations;
using StateTrackerProject.Interfaces;

namespace StateTrackerProject.Domain
{
    public class Board : IBoard
    {
        public char[] BoardLetters { get; }
        public ModelState State { get; private set; }
        public CoordinateState[,] Coordinates { get; private set; }
        public List<Ship> Ships { get; private set; }

        public Board()
        {
            State = ModelState.Inactive;

            BoardLetters = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
        }

        public bool ActivateBoard()
        {
            Ships = new List<Ship>();
            Coordinates = new CoordinateState[BoardLetters.Length, BoardLetters.Length];

            for (var i = 0; i < BoardLetters.Length; i++)
            {
                for (var j = 0; j < BoardLetters.Length; j++)
                {
                    Coordinates[i, j] = CoordinateState.Free;
                }
            }

            State = ModelState.Active;
            return true;
        }

        public bool PlaceShip(Coordinate initialCoordinate, int length, ShipOrientation shipOrientation)
        {
            if (!ValidateShipCreationData(initialCoordinate, length, shipOrientation))
                return false;

            var coordinates = GenerateShipCoordinates(initialCoordinate, length, shipOrientation)?.ToList();

            if (coordinates == null)
                return false;

            var ship = new Ship(coordinates);
            Ships.Add(ship);

            ChangeCoordinatesState(coordinates, CoordinateState.Occupied);

            return true;
        }

        public bool AssessAttack(Coordinate attackCoordinate)
        {
            if (Coordinates[attackCoordinate.X, attackCoordinate.Y] == CoordinateState.Occupied)
            {
                var ship = Ships.Select(s => s).First(s => s.Coordinates.ContainsKey(attackCoordinate));
                ship.TakeHit(attackCoordinate);

                Coordinates[attackCoordinate.X, attackCoordinate.Y] = CoordinateState.Hit;

                if (ship.IsShipSunk())
                    Ships.Remove(ship);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Changes the state of the Coordinate
        /// </summary>
        /// <param name="coordinates">A collection of Coordinates</param>
        /// <param name="coordinateState">The new Coordinate State to be assigned</param>
        private void ChangeCoordinatesState(IEnumerable<Coordinate> coordinates, CoordinateState coordinateState)
        {
            foreach (var coordinate in coordinates)
            {
                Coordinates[coordinate.X, coordinate.Y] = coordinateState;
            }
        }

        /// <summary>
        /// Checks if the data passed to create a Ship is valid, i.e. no coordinate is out of the board
        /// </summary>
        /// <param name="initialCoordinate">The origin coordinate</param>
        /// <param name="length">The length of the Ship</param>
        /// <param name="shipOrientation">Whether the ship is facing North, South, East or West from the
        /// Coordinate of origin</param>
        /// <returns>True if the data creates Coordinates that are all on the board</returns>
        private bool ValidateShipCreationData(Coordinate initialCoordinate, int length,
            ShipOrientation shipOrientation)
        {
            if (!IsCoordinateFree(initialCoordinate))
                return false;

            if ((shipOrientation == ShipOrientation.South && initialCoordinate.Y - (length - 1) < 0) ||
                (shipOrientation == ShipOrientation.West && initialCoordinate.X - (length - 1) < 0) ||
                (shipOrientation == ShipOrientation.North && initialCoordinate.Y + (length - 1) > 9) ||
                (shipOrientation == ShipOrientation.East && initialCoordinate.X + (length - 1) > 9))
                return false;

            return true;
        }

        /// <summary>
        /// Checks whether a Coordinate is not occupied by any Ship
        /// </summary>
        /// <param name="coordinate">The Coordinate to check</param>
        /// <returns>True if the Coordinate is Free</returns>
        private bool IsCoordinateFree(Coordinate coordinate)
        {
            return Coordinates[coordinate.X, coordinate.Y] == CoordinateState.Free;
        }

        /// <summary>
        /// Based on the Ship creation data, it generates all the Coordinates necessary to place a Ship on the board
        /// </summary>
        /// <param name="initialCoordinate">The Coordinate of origin</param>
        /// <param name="length">The length of the Ship</param>
        /// <param name="shipOrientation">Whether the ship is facing North, South, East or West from the
        /// Coordinate of origin</param>
        /// <returns>A collection of Coordinates to be assigned to a Ship to be created</returns>
        private IEnumerable<Coordinate> GenerateShipCoordinates(Coordinate initialCoordinate, int length,
            ShipOrientation shipOrientation)
        {
            var coordinates = new List<Coordinate> { initialCoordinate };

            switch (shipOrientation)
            {
                case ShipOrientation.North:
                    for (var i = initialCoordinate.Y + 1; i < (initialCoordinate.Y + length); i++)
                    {
                        var coordinate = new Coordinate(initialCoordinate.X, i);
                        if (!IsCoordinateFree(coordinate))
                            return null;

                        coordinates.Add(coordinate);
                    }
                    break;
                case ShipOrientation.South:
                    for (var i = initialCoordinate.Y - 1; i > (initialCoordinate.Y - length); i--)
                    {
                        var coordinate = new Coordinate(initialCoordinate.X, i);
                        if (!IsCoordinateFree(coordinate))
                            return null;

                        coordinates.Add(coordinate);
                    }
                    break;
                case ShipOrientation.East:
                    for (var i = initialCoordinate.X + 1; i < (initialCoordinate.X + length); i++)
                    {
                        var coordinate = new Coordinate(i, initialCoordinate.Y);
                        if (!IsCoordinateFree(coordinate))
                            return null;

                        coordinates.Add(coordinate);
                    }
                    break;
                case ShipOrientation.West:
                    for (var i = initialCoordinate.X - 1; i > (initialCoordinate.X - length); i--)
                    {
                        var coordinate = new Coordinate(i, initialCoordinate.Y);
                        if (!IsCoordinateFree(coordinate))
                            return null;

                        coordinates.Add(coordinate);
                    }
                    break;
                default:
                    return null;
            }

            return coordinates;
        }
    }
}