namespace RoShamBo5.Tiles
{
    public class Tile5 : Tile
    {
        /// <summary>
        /// This tile wins agains Tile 1 and Tile 3 and loses to Tile 2 and Tile 4
        /// </summary>
        public Tile5() { }

        public override bool Win(Tile compare)
        {
            if (compare.GetType() == new Tile1().GetType()) return true;
            if (compare.GetType() == new Tile3().GetType()) return true;
            return false;
        }
    }
}