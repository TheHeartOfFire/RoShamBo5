namespace RoShamBo5.Tiles
{
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