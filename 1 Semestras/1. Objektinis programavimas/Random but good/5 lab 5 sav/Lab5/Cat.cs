using System;

namespace Lab3.Step1
{
    class Cat : AnimalMarked
    {
        private static int VaccinationDurationMonths = 6;

        public Cat(string name, string breed, string owner, string phone, DateTime vaccinationDate, int chipId)
            : base(name, breed, owner, phone, vaccinationDate, chipId)
        {
        }
        public Cat(string data) : base(data)
        {
            SetData(data);
        }

        //abstraktaus Animal klasės metodo realizacija
        public override bool isVaccinationExpired()
        {
            return VaccinationDate.AddMonths(VaccinationDurationMonths).CompareTo(DateTime.Now) > 0;
        }

        public override String ToString()
        {
            return base.ToString();
        }
    }
}
