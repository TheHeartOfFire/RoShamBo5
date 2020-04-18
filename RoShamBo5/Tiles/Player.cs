using System.Collections.Generic;

namespace RoShamBo5.Tiles
{
    public class Player
    {
        public bool Lost;
        public Tile Left;
        public Tile Right;
        public List<Tile> Hand = new List<Tile>();

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