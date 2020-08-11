using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Step1
{
    class GuineaPig : Animal
    {
        private static int VaccinationDurationMonths = 3;
        public GuineaPig(string name,  string breed, string owner, string phone, DateTime vaccinationDate)
            : base(name, breed, owner, phone, vaccinationDate)
        {
        }
        public GuineaPig(string data) : base(data)
        {
            SetData(data);
        }
        public override bool isVaccinationExpired()
        {
            return VaccinationDate.AddMonths(VaccinationDurationMonths).CompareTo(DateTime.Now) > 0;
        }
        public override String ToString()
        {
            return base.ToString();
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as GuineaPig);
        }

        public bool Equals(GuineaPig guineapig)
        {
            return base.Equals(guineapig);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(GuineaPig lhs, GuineaPig rhs)
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

        public static bool operator !=(GuineaPig lhs, GuineaPig rhs)
        {
            return !(lhs == rhs);
        }
    }
}
