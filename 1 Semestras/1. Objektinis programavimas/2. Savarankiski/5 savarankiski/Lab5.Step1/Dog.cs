using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Step1
{
    class Dog : AnimalMarked
    {
        private static int VaccinationDuration = 1;

        public Dog (string name, int chipId, string breed, string owner, string phone, DateTime vaccinationDate, bool aggressive) :
            base(name, breed, chipId, owner, phone, vaccinationDate)
        {
            Aggressive = aggressive;
        }

        public Dog (string data) : base (data)
        {
            SetData(data);
        }

        public override void SetData(string line)
        {
            base.SetData(line);
            string[] values = line.Split(',');
            Aggressive = bool.Parse(values[7]);
        }

        public bool Aggressive { get; set; }

        //abstrataus Animal klases metodo realizacija
        public override bool isVaccinationExpired ()
        {
            return VaccinationDate.AddYears(VaccinationDuration).CompareTo(DateTime.Now) > 0;

        }
        public override string ToString()
        {
            return String.Format("|{0,-3}|{1,-20}|{2,-9}|{3,-10} ({4})|{5:yyyy-MM-dd}|{6}|", ChipId, Breed, Name, Owner, Phone, VaccinationDate, Aggressive ? '+' : ' ');        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Dog); //kvieciame tipui specifini metoda toje pacioje klaseje

        }
        public bool Equals (Dog dog)
        {
            return base.Equals(dog);
        }
        public override int GetHashCode ()
        {
            return ChipId.GetHashCode() ^ Name.GetHashCode();
        }
        public static bool operator == (Dog lhs, Dog rhs)
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
        public static bool operator !=(Dog lhs, Dog rhs)
        {
            return !(lhs == rhs);
        }
        //public static bool operator <= (AnimalMarked lhs, AnimalMarked rhs)
        //{
        //    return (lhs.ChipId < rhs.ChipId);
        //}
        //public static bool operator >=(AnimalMarked lhs, AnimalMarked rhs)
        //{
        //    return (lhs.ChipId > rhs.ChipId);
        //}
    }
}
