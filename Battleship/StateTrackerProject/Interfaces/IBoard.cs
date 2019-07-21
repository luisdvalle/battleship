using System.Collections.Generic;
using StateTrackerProject.Domain;
using StateTrackerProject.Enumerations;

namespace StateTrackerProject.Interfaces
{
    /// <summary>
    /// Defines the basic characteristics and functionality of a _board
    /// </summary>
    public interface IBoard
    {
        ModelState State { get; }
        char[] BoardLetters { get; }
        List<Ship> Ships { get; }

        /// <summary>
        /// Prepares Board for a game 
        /// </summary>
        /// <returns>true if Board is activated successfully</returns>
        bool ActivateBoard();

        /// <summary>
        /// Plae a Ship on the board
        /// </summary>
        /// <param name="initialCoordinate">The first Coordinate of the Ship</param>
        /// <param name="length">Represents the number of coordinates the Ship will occupy</param>
        /// <param name="shipOrientation">Whether the Ship is align towards north, south, east or west from the
        /// Initial Coordinate</param>
        /// <returns>True if Ship was successfully placed on the Board</returns>
        bool PlaceShip(Coordinate initialCoordinate, int length, ShipOrientation shipOrientation);

        /// <summary>
        /// Checks if an attack has hit a Coordinate occupied by a Ship
        /// </summary>
        /// <param name="attackCoordinate">The Coordinate of the Attack</param>
        /// <returns>True if the attack was a Hit</returns>
        bool AssessAttack(Coordinate attackCoordinate);
    }
}
