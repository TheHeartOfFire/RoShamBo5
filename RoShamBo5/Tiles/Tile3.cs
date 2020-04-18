﻿namespace RoShamBo5.Tiles
{/// <summary>
/// This tile wins agains Tile 4 and Tile 1 and loses to Tile 5 and Tile 2
/// </summary>
    public class Tile3 : Tile
    {
        public override bool Win(Tile compare)
        {
            if (compare.GetType() == new Tile4().GetType()) return true;
            if (compare.GetType() == new Tile1().GetType()) return true;
            return false;
        }
    }
}