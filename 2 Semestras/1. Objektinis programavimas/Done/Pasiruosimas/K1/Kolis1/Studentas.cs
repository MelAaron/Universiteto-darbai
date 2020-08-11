using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kolis1
{
    public class Studentas
    {
        public string Pavarde { get; set; }
        public string Vardas { get; set; }
        public string Grupe { get; set; }
        public int[] Kreditai { get; set; }
        public int Suma { get; private set; }

        public Studentas (string pavarde, string vardas, string grupe, int[] kreditai)
        {
            Kreditai = new int[Dydis(kreditai)];
            Pavarde = pavarde;
            Vardas = vardas;
            Grupe = grupe;
            int a = 0;
            for (int i = 0; i < kreditai.Length; i++)
                if (kreditai[i] != 0)
                    Kreditai[a++] = kreditai[i];
                    


            //Kreditai = kreditai;
        }

        private int Dydis(int[] masyvas)
        {
            int a = 0;
            for (int i = 0; i < masyvas.Length; i++)
                if (masyvas[i] != 0)
                    a++;
            return a;
        }

        public int KredituSuma (int index)
        {
            if (index >= Kreditai.Length)
                return Suma;
            else
            {
                Suma += Kreditai[index];
                KredituSuma(index + 1);
            }
            return Suma;
        }

        //public static bool operator >= (Studentas st1, Studentas st2)
        //{
        //    if(st1.Grupe.CompareTo(st2.Grupe) == 0)
        //    {
        //        if (st1.Pavarde.CompareTo(st2.Pavarde) == 1)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    if (st2.Grupe.CompareTo(st2.Grupe) == 1)
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
        //}
        //public static bool operator <= (Studentas st1, Studentas st2)
        //{
        //    if (st1.Grupe.CompareTo(st2.Grupe) == 0)
        //    {
        //        if (st1.Pavarde.CompareTo(st2.Pavarde) == -1)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    if (st2.Grupe.CompareTo(st2.Grupe) == -1)
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
        //}
        //public override bool Equals(object obj)
        //{
        //    return this.Equals(obj as Studentas);
        //}
        //public bool Equals (Studentas studentas)
        //{
        //    if(object.ReferenceEquals(studentas, null))
        //    {
        //        return false;
        //    }
        //    if(studentas.GetType() != this.GetType())
        //    {
        //        return false;
        //    }
        //    return studentas.Pavarde == Pavarde && studentas.Grupe == Grupe;
        //}
        //public override int GetHashCode()
        //{
        //    return Pavarde.GetHashCode() ^ Grupe.GetHashCode();
        //}

        public override string ToString()
        {
            string kreditai = "";
            for (int i = 0; i < Kreditai.Length; i++)
                kreditai += " " + Kreditai[i].ToString();
            return String.Format("{0, 20} | {1, 20} | {2, 20} | {3, 20} |", Pavarde, Vardas, Grupe, kreditai);
        }

        //public override bool Equals(object obj)
        //{
        //    return this.Equals(obj as Studentas);
        //}
        //public bool Equals (Studentas studentas)
        //{
        //    if (object.ReferenceEquals(studentas, null))
        //        return false;
        //    if (studentas.GetType() != this.GetType())
        //        return false;
        //    return studentas.Pavarde == Pavarde && studentas.Grupe == Grupe;
        //}
        //public override int GetHashCode()
        //{
        //    return Pavarde.GetHashCode() ^ Grupe.GetHashCode();
        //}
        //public static bool operator >= (Studentas s1, Studentas s2)
        //{
        //    if(s1.Grupe.CompareTo(s2.Grupe) == 0)
        //    {
        //        if(s1.Pavarde.CompareTo(s2.Pavarde) == 1)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    if (s1.Grupe.CompareTo(s2.Grupe) == 1)
        //        return true;
        //    else
        //        return false;
        //}
        //public static bool operator <= (Studentas s1, Studentas s2)
        //{
        //    if (s1.Grupe.CompareTo(s2.Grupe) == 0)
        //    {
        //        if (s1.Pavarde.CompareTo(s2.Pavarde) == -1)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    if (s1.Grupe.CompareTo(s2.Grupe) == -1)
        //        return true;
        //    else
        //        return false;
        //}

        //public static bool operator == (Studentas s1, Studentas s2)
        //{
        //    if(Object.ReferenceEquals(s1, null))
        //    {
        //        if(Object.ReferenceEquals(s2, null))
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    return s1.Equals(s2);
        //}
        //public static bool operator != (Studentas s1, Studentas s2)
        //{
        //    return !(s1.Equals(s2));
        //}

        //public override bool Equals(object obj)
        //{
        //    return this.Equals(obj as Studentas);
        //}
        //public bool Equals(Studentas studentas)
        //{
        //    if (object.ReferenceEquals(studentas, null))
        //        return false;
        //    if (studentas.GetType() == this.GetType())
        //        return false;
        //    return studentas.Grupe == Grupe && studentas.Pavarde == Pavarde;
        //}
        //public override int GetHashCode()
        //{
        //    return Grupe.GetHashCode() ^ Pavarde.GetHashCode();
        //}
        //public static bool operator <= (Studentas s1, Studentas s2)
        //{
        //    if(s1.Grupe.CompareTo(s2.Grupe) == 0)
        //    {
        //        if(s1.Pavarde.CompareTo(s2.Pavarde) == -1)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    if (s1.Grupe.CompareTo(s2.Grupe) == -1)
        //        return true;
        //    else
        //        return false;
        //}
        //public static bool operator >=(Studentas s1, Studentas s2)
        //{
        //    if (s1.Grupe.CompareTo(s2.Grupe) == 0)
        //    {
        //        if (s1.Pavarde.CompareTo(s2.Pavarde) == 1)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    if (s1.Grupe.CompareTo(s2.Grupe) == 1)
        //        return true;
        //    else
        //        return false;
        //}
        //public static bool operator == (Studentas s1, Studentas s2)
        //{
        //    if(Object.ReferenceEquals(s1, null))
        //    {
        //        if(Object.ReferenceEquals(s2, null))
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    return s1.Equals(s2);
        //}
        //public static bool operator != (Studentas s1, Studentas s2)
        //{
        //    return !(s1.Equals(s2));
        //}

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Studentas);
        }
        public bool Equals(Studentas studentas)
        {
            if (object.ReferenceEquals(studentas, null))
                return false;
            if (studentas.GetType() != this.GetType())
                return false;
            return studentas.Grupe == Grupe && studentas.Pavarde == Pavarde;
        }
        public override int GetHashCode()
        {
            return Grupe.GetHashCode() ^ Pavarde.GetHashCode();
        }
        public static bool operator >=(Studentas st1, Studentas st2)
        {
            if(st1.Grupe.CompareTo(st2.Grupe) == 0)
            {
                if(st1.Grupe.CompareTo(st2.Grupe) == 1)
                {
                    return true;
                }
                return false;
            }
            if (st1.Grupe.CompareTo(st2.Grupe) == 1)
                return true;
            else
                return false;
        }
        public static bool operator <=(Studentas st1, Studentas st2)
        {
            if (st1.Grupe.CompareTo(st2.Grupe) == 0)
            {
                if (st1.Grupe.CompareTo(st2.Grupe) == -1)
                {
                    return true;
                }
                return false;
            }
            if (st1.Grupe.CompareTo(st2.Grupe) == -1)
                return true;
            else
                return false;
        }
        public static bool operator == (Studentas st1, Studentas st2)
        {
            if(Object.ReferenceEquals(st1, null))
            {
                if(Object.ReferenceEquals(st2, null))
                {
                    return true;
                }
                return false;
            }
            return st1.Equals(st2);
        }
        public static bool operator !=(Studentas st1, Studentas st2)
        {
            return !(st1.Equals(st2));
        }
    }
}