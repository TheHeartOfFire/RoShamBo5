namespace RoShamBo5.Tiles
{
    public class Tile5 : Tile
    {
        public override bool Win(Tile compare)
        {
            if (compare.GetType() == new Tile1().GetType()) return true;
            if (compare.GetType() == new Tile3().GetType()) return true;
            return false;
        }
    }
}