namespace RoShamBo5.Tiles
{
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