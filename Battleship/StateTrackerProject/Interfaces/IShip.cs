using StateTrackerProject.Domain;

namespace StateTrackerProject.Interfaces
{
    /// <summary>
    /// Defines the functionality of a Ship
    /// </summary>
    public interface IShip
    {
        /// <summary>
        /// Whether a Ship has been sunk or is still active
        /// </summary>
        /// <returns>True if the Ship has been sunk</returns>
        bool IsShipSunk();

        /// <summary>
        /// Process a Hit in a Coordinate occupied by a SHip
        /// </summary>
        /// <param name="coordinate">The Coordinate occupied by a Ship</param>
        void TakeHit(Coordinate coordinate);
    }
}
