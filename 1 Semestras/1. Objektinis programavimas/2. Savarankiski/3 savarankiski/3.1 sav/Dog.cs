using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Step1
{
    class Dog : AnimalMarked
    {
        private static int VaccinationDuration = 1;

        public Dog(string name, int chipId, string breed, string owner, string phone, DateTime vaccinationDate, bool aggressive) : base(name, breed, chipId, owner, phone, vaccinationDate)
        {
            Aggressive = aggressive;
        }

        public bool Aggressive { get; set; }

        //abstraktaus Animal klasės metodo realizacija
        public override bool isVaccinationExpired()
        {
            return VaccinationDate.AddYears(VaccinationDuration).CompareTo(DateTime.Now) > 0;
        }

        public override String ToString()
        {
            return String.Format("ChipId: {0,-5} Breed: {1,-15} Name: {2,-10} Owner: {3,-10} ({4}) Last vaccination date: {5:yyyy - MM - dd} Agressive: {6}", ChipId, Breed, Name, Owner, Phone, VaccinationDate, Aggressive);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Dog); //kviečiame tipui specifinį metodą toje pačiojeklasėje
        }

        public bool Equals(Dog dog)
        {
            return base.Equals(dog); //kviečiame tėvinės klasės Animal Equals metodą
                                     //galima papildomai tikrinti pagal tik Dog klasės būdingas sąvybes, pvz
                                     //return base.Equals(dog) && this.Aggressive == dog.Aggressive;
        }

        public override int GetHashCode()
        {
            return Owner.GetHashCode() ^ Name.GetHashCode();
        }

        public static bool operator ==(Dog lhs, Dog rhs)
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
    }
}
