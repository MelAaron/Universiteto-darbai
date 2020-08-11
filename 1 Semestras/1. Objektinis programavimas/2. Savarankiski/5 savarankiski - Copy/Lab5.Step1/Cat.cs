﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Step1
{
    class Cat : AnimalMarked
    {
        private static int VaccinationDurationMonths = 6;

        public Cat (string name, int chipId, string breed, string owner, string phone, DateTime vaccinationDate) :
            base (name, breed, chipId, owner, phone, vaccinationDate)
        {
        }

        public Cat (string data) : base(data)
        {
            SetData(data);
        }

        //abstraktaus Animal klass metoo realizacija
        public override bool isVaccinationExpired()
        {
            return VaccinationDate.AddMonths(VaccinationDurationMonths).CompareTo(DateTime.Now) > 0;
        }
        public override string ToString()
        {
            return String.Format("|{0,-3}|{1,-20}|{2,-9}|{3,-10} ({4})|{5:yyyy-MM-dd}|", ChipId, Breed, Name, Owner, Phone, VaccinationDate);
        //public static bool operator <=(AnimalMarked lhs, AnimalMarked rhs)
        //{
        //    return (lhs.ChipId < rhs.ChipId);
        //}
        //public static bool operator >=(AnimalMarked lhs, AnimalMarked rhs)
        //{
        //    return (lhs.ChipId > rhs.ChipId);
        //}
        //public override bool Equals(object obj)
        //{
        //    return this.Equals(obj as AnimalMarked);
        //}
        //public bool Equals(AnimalMarked cat)
        //{
        //    return base.Equals(cat);
        //}
        //public override int GetHashCode()
        //{
        //    return ChipId.GetHashCode() ^ Name.GetHashCode();
        //}

        //public static bool operator ==(Cat lhs, Cat rhs)
        //{
        //    if(Object.ReferenceEquals(lhs, null))
        //    {
        //        if(Object.ReferenceEquals(rhs,null))
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    return lhs.Equals(rhs);
        //}
        //public static bool operator != (Cat lhs, Cat rhs)
        //{
        //    return !(lhs == rhs);
        //}
    }
}