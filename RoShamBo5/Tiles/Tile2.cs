namespace RoShamBo5.Tiles
{/// <summary>
/// This tile wins agains Tile 3 and Tile 5 and loses to Tile 4 and Tile 1
/// </summary>
    public class Tile2 : Tile
    {
        public override bool Win(Tile compare)
        {
            if (compare.GetType() == new Tile3().GetType()) return true;
            if (compare.GetType() == new Tile5().GetType()) return true;
            return false;
        }
    }
}