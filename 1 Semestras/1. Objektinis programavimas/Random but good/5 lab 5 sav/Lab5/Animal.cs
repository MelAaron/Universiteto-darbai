using System;

namespace Lab3.Step1
{
    abstract class Animal
    {
        public string Name { get; set; }
        //public int ChipId { get; set; }
        public string Breed { get; set; }
        public string Owner { get; set; }
        public string Phone { get; set; }
        public DateTime VaccinationDate { get; set; }
        public Animal(string name, string breed, string owner, string phone, DateTime vaccinationDate)
        {
            Name = name;
            //CipId = chipId;
            Breed = breed;
            Owner = owner;
            Phone = phone;
            VaccinationDate = vaccinationDate;
        }
        public Animal()
        {
        }
        public Animal(string data)
        {
            SetData(data);
        }
        public virtual void SetData(string line)
        {
            string[] values = line.Split(',');
            Name = values[1];
           //ChipId = int.Parse(values[2]);
            Breed = values[2];
            Owner = values[3];
            Phone = values[4];
            VaccinationDate = DateTime.Parse(values[5]);
        }
        /// <summary>
        /// Metodas paskelbtas abstrakčiu. Tai reiškia, jog vaikų klasės privalės jį realizuoti
        /// <summary>
        abstract public bool isVaccinationExpired();
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
            return  (Name == animal.Name) && (Owner == animal.Owner);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Owner.GetHashCode();
        }
        public static bool operator ==(Animal lhs, Animal rhs)
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
        public static bool operator !=(Animal lhs, Animal rhs)
        {
            return !(lhs == rhs);
        }
        public static bool operator <=(Animal lhs, Animal rhs)
        {
            if (lhs.Name.CompareTo(rhs.Name) == 0)
                return lhs.Owner.CompareTo(rhs.Owner) <= 0;
            return lhs.Name.CompareTo(rhs.Name) <= 0;

        }
        public static bool operator >=(Animal lhs, Animal rhs)
        {
            if (lhs.Name.CompareTo(rhs.Name) == 0)
                return lhs.Owner.CompareTo(rhs.Owner) >= 0;
            return lhs.Name.CompareTo(rhs.Name) >= 0;
        }
        public override String ToString()
        {
            return String.Format("|{0,-20}|{1,-9}|{2,-10} ({3})|{4:yyyy-MM-dd}|", Breed, Name, Owner, Phone, VaccinationDate);
        }
    }
}
