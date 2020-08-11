using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    abstract class AnimalMarked : Animal
    {
        public int ChipId { get; set; }

        public AnimalMarked(string name, int chipId, string breed, string owner, string phone, DateTime vaccinationDate) :
            base (name, breed, owner, phone, vaccinationDate)
        {
            ChipId = chipId;
        }

        override abstract public bool isVaccinationExpired();

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Animal);
        }
        public bool Equals(Animal animal)
        {
            if (Object.ReferenceEquals(animal, null))
            {
                return false;
            }
            if (this.GetType() != animal.GetType())
            {
                return false;
            }
            return (Owner == animal.Owner) && (Name == animal.Name);
        }
        public override int GetHashCode()
        {
            return Owner.GetHashCode() ^ Name.GetHashCode();
        }
        public static bool operator ==(AnimalMarked lhs, AnimalMarked rhs)
        {
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return false;
                }
            }
            return lhs.Equals(rhs);
        }
        public static bool operator !=(AnimalMarked lhs, AnimalMarked rhs)
        {
            return !(lhs == rhs);
        }
        public static bool operator <=(AnimalMarked lhs, AnimalMarked rhs)
        {
            if (lhs.Name[0] == rhs.Name[0])
            {
                return (lhs.Owner[0] <= rhs.Owner[0]);
            }
            return (lhs.Name[0] <= rhs.Name[0]);

        }
        public static bool operator >=(AnimalMarked lhs, AnimalMarked rhs)
        {
            if (lhs.Name[0] == rhs.Name[0])
            {
                return lhs.Owner[0] > lhs.Owner[0];
            }
            return (lhs.Name[0] > rhs.Name[0]);
        }
    }

}
