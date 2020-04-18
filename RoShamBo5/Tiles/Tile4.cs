namespace RoShamBo5.Tiles
{/// <summary>
/// This tile wins agains Tile 5 and Tile 2 and loses to Tile 1 and Tile 3
/// </summary>
    public class Tile4 : Tile
    {
        public override bool Win(Tile compare)
        {
            if (compare.GetType() == new Tile5().GetType()) return true;
            if (compare.GetType() == new Tile2().GetType()) return true;
            return false;
        }
    }
}