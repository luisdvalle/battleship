namespace StateTrackerProject.Interfaces
{
    /// <summary>
    /// Encapsulates properties and functionality for a Battleship Game
    /// </summary>
    public interface IGame
    {
        IPlayer Player { get; }
        bool Active { get; set; }

        /// <summary>
        /// Activates the Game for playing
        /// </summary>
        /// <returns>True if the Game is successfully activated</returns>
        bool ActivateGame();

        /// <summary>
        /// Prepares data to place a new Ship on the Board
        /// </summary>
        /// <param name="x">The X element of the Coordinate represented by a character from 'a' to 'j'</param>
        /// <param name="y">The Y element of the Coordinate represented by a number from 1 to 10</param>
        /// <param name="length">The length of the Ship</param>
        /// <param name="orientationCode">A code representing the orientation of the Ship represented by a one of the
        /// following characters: 'n', 's', 'e' or 'w'</param>
        /// <returns></returns>
        bool AddShipToBoard(char x, int y, int length, char orientationCode);

        /// <summary>
        /// Directs an Attack on a specific Coordinate
        /// </summary>
        /// <param name="x">The X element of the Coordinate represented by a character from 'a' to 'j'</param>
        /// <param name="y">The Y element of the Coordinate represented by a number from 1 to 10</param>
        /// <returns>True if the Attack resulted in a Hit</returns>
        bool AttackCoordinate(char x, int y);

        /// <summary>
        /// Evaluates the number of Ships still active on the game
        /// </summary>
        /// <returns>The number of active Ships</returns>
        int ActiveShips();
    }
}
