using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Step1
{
    abstract class AnimalMarked : Animal
    {
        public AnimalMarked(string name, string breed, string owner, string phone, DateTime vaccinationDate, int chipid)
            : base(name, breed, owner, phone, vaccinationDate)
        {
            ChipId = chipid;
        }
        public int ChipId { get; set; }
        public AnimalMarked(string data)
        {
            SetData(data);
        }
        public override void SetData(string line)
        {
            string[] values = line.Split(',');
            Name = values[1];
            ChipId = int.Parse(values[2]);
            Breed = values[3];
            Owner = values[4];
            Phone = values[5];
            VaccinationDate = DateTime.Parse(values[6]);
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as AnimalMarked);
        }
        public bool Equals(AnimalMarked animal)
        {
            if (Object.ReferenceEquals(animal, null))
            {
                return false;
            }

            if (this.GetType() != animal.GetType())
            {
                return false;
            }

            return (ChipId == animal.ChipId) && (Name == animal.Name);
        }
        public static bool operator ==(AnimalMarked lhs, AnimalMarked rhs)
        {
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }

                return false;
            }
            return lhs.Equals(rhs);
        }
        public static bool operator !=(AnimalMarked lhs, AnimalMarked rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            return ChipId.GetHashCode() ^ Name.GetHashCode();
        }
        public static bool operator <=(AnimalMarked lhs, AnimalMarked rhs)
        {
            return (lhs.ChipId <= rhs.ChipId);
        }

        public static bool operator >=(AnimalMarked lhs, AnimalMarked rhs)
        {
            return (lhs.ChipId >= rhs.ChipId);
        }
        public override String ToString()
        {
            return String.Format("|{0,-3}|{1,-20}|{2,-9}|{3,-10} ({4})|{5:yyyy-MM-dd}|", ChipId, Breed, Name, Owner, Phone, VaccinationDate);
        }
    }
}
