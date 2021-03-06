﻿namespace RoShamBo5.Tiles
{
    public class Tile1 : Tile
    {
        /// <summary>
        /// This tile wins agains Tile 2 and Tile 4 and loses to Tile 3 and Tile 5
        /// </summary>
        public Tile1() { }

        public override bool Win(Tile compare)
        {
            if (compare.GetType() == new Tile2().GetType()) return true;
            if (compare.GetType() == new Tile4().GetType()) return true;
            return false;
        }
    }
}