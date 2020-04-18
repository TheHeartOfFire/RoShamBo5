using System;

namespace RoShamBo5
{/// <summary>
/// Base Class for tiles used for polymorphic grouping.
/// </summary>
    public abstract class Tile
    {
        public abstract bool Win(Tile compare);

        public int Quantity;

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return obj.GetType() == GetType();
        }

        public override int GetHashCode()
        {
            throw new Exception("Sorry I don't know what GetHashCode should do for this class");
        }
    }
}