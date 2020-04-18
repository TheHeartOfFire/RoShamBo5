namespace RoShamBo5
{
    public abstract class Tile
    {
        public abstract bool Win(Tile compare);

        public int Quantity;

        public override bool Equals(object obj)
        {
            return obj.GetType() == GetType();
        }
    }
}