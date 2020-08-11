using System;
namespace Lab3.Step1
{
    class Dog : AnimalMarked
    {
        private static int VaccinationDuration = 1;

        public Dog(string name, string breed, string owner, string phone, DateTime vaccinationDate, int chipId, bool aggressive) : base(name, breed, owner, phone, vaccinationDate, chipId)
        {
            Aggressive = aggressive;
        }

        public bool Aggressive { get; set; }
        public Dog(string data) : base(data)
        {
            SetData(data);
        }
        public override void SetData(string line)
        {
            base.SetData(line);
            string[] values = line.Split(',');
            Aggressive = bool.Parse(values[7]);
        }
        //abstraktaus Animal klasės metodo realizacija
        public override bool isVaccinationExpired()
        {
            return VaccinationDate.AddYears(VaccinationDuration).CompareTo(DateTime.Now) > 0;
        }
        public override String ToString()
        {
            return base.ToString();
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Dog); //kviečiame tipui specifinį metodą toje pačioje klasėje
        }
        public bool Equals(Dog dog)
        {
            return base.Equals(dog); //kviečiame tėvinės klasės Animal Equals metodą
                                     //galima papildomai tikrinti pagal tik Dog klasės būdingas savybes, pvz
                                     //return base.Equals(dog) && this.Aggressive == dog.Aggressive;
        }
        public override int GetHashCode()
        {
            return ChipId.GetHashCode() ^ Name.GetHashCode();
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
