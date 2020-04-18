namespace RoShamBo5.Tiles
{
    public class Tile1 : Tile
    {
        public override bool Win(Tile compare)
        {
            if (compare.GetType() == new Tile2().GetType()) return true;
            if (compare.GetType() == new Tile4().GetType()) return true;
            return false;
        }
    }
}