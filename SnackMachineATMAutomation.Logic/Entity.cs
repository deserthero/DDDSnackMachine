using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackMachineATMAutomation.Logic
{
    public abstract class Entity
    {
        // Long datatype is easier than GUID but you can use it if you want
        public long Id { get; private set; }

        // The default Equals implementation gives us reference equality we want to override it to provide Identity equality so if they have the same ref. they equal but if not we check
        // for the identity as below.
        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (this.GetType() != other.GetType())
                return false;

            if (this.Id == 0 || other.Id == 0)
                return false;

            return this.Id == other.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }


        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        // It's important for 2 objects which they are equal to each other to always generate the same hashcode
        public override int GetHashCode()
        {
            return (this.GetType().ToString() + this.Id).GetHashCode();
        }
    }
}
