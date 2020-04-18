using System.Collections.Generic;

namespace RoShamBo5.Tiles
{/// <summary>
/// This object hold all required data for the player.
/// </summary>
    public class Player
    {
        public bool Lost;
        public Tile Left;
        public Tile Right;
        public List<Tile> Hand = new List<Tile>();

        /// <summary>
        /// Counts the total number of tiles that the player has.
        /// Mostly used to detect win/loss conditions.
        /// </summary>
        /// <returns>Total number of tiles left.</returns>
        public int Count()
        {
            var output = 0;
            foreach (var tile in Hand)
            {
                output += tile.Quantity;
            }
            return output;
        }
    }
}