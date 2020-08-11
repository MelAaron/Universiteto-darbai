using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kolis1
{
    public class Fakultetas
    {
        public string FakultetoPav { get; set; }
        public int Kreditai { get; set; }
        public int Moduliai { get; set; }
        private Studentas[] Studentai { get; set; }
        public int Count { get; set; }

        public Fakultetas(int size, string fak, int kre, int mod)
        {
            FakultetoPav = fak;
            Kreditai = kre;
            Moduliai = mod;
            Studentai = new Studentas[size];
            Count = 0;
        }

        public Fakultetas(int size)
        {
            Studentai = new Studentas[size];
            Count = 0;
        }
        public void PridetiStudenta (Studentas studentas)
        {
            if(studentas != null)
            Studentai[Count++] = studentas;
        }
        public void NustatytiStudenta (Studentas studentas, int index)
        {
            Studentai[index] = studentas;
        }
        public Studentas GautiStudenta(int index)
        {
            return Studentai[index];
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Fakultetas);
        }
        public bool Equals(Fakultetas fakultetas)
        {
            if (Object.ReferenceEquals(fakultetas, null))
            {
                return false;
            }
            if (fakultetas.GetType() != this.GetType())
            {
                return false;
            }
            return fakultetas.Count == Count;
        }
        public override int GetHashCode()
        {
            return Count.GetHashCode();
        }
        public static bool operator ==(Fakultetas f1, Fakultetas f2)
        {
            if (Object.ReferenceEquals(f1, null))
            {
                if (Object.ReferenceEquals(f2, null))
                {
                    return true;
                }
                return false;
            }
            return f1.Equals(f2);
        }
        public static bool operator !=(Fakultetas f1, Fakultetas f2)
        {
            return !(f1.Equals(f2));
        }
        public static bool operator >(Fakultetas f1, Fakultetas f2)
        {
            if (f1.Count == f2.Count)
                return true;
            else
                return f1.Count > f2.Count;

        }
        public static bool operator <(Fakultetas f1, Fakultetas f2)
        {
            return f1.Count < f2.Count;
        }

        public void Burbulas()
        {
            int j = 1;
            bool bk = true;
            while(bk)
            {
                bk = false;
                for (int i = Count - 1; i > j; i--)
                {
                    if(Studentai[j] >= Studentai[j-1])
                    {
                        bk = true;
                        Studentas c= Studentai[j];
                        Studentai[j] = Studentai[j - 1];
                        Studentai[j - 1] = c;
                    }
                }
                j++;
            }
        }

        public void Isrinkimas()
        {
            for (int i = 0; i < Count; i++)
            {
                int max = i;
                for (int j = i + 1; j < Count; j++)
                {
                    if (Studentai[j] >= Studentai[i])
                        max = j;
                }
                if (max != i)
                {
                    Studentas a = Studentai[i];
                    Studentai[i] = Studentai[max];
                    Studentai[max] = a;
                }
            }
        }

        public void B ()
        {
            int j = 0;
            bool bk = true;
            while (bk)
            {
                bk = false;
                for (int i = Count - 1; i > j; i--)
                {
                    if(Studentai[i] >= Studentai[i - 1])
                    {
                        bk = true;
                        var c = Studentai[j];
                        Studentai[j] = Studentai[i];
                        Studentai[i] = c;
                    }
                }
                j++;
            }
        }

        public void I ()
        {
            for (int i = 0; i < Count; i++)
            {
                int max = i;
                for (int j = i + 1; j < Count; j++)
                {
                    if(Studentai[j] >= Studentai[max])
                    {
                        max = j;
                    }
                }
                if(max != i)
                {
                    var c = Studentai[max];
                    Studentai[max] = Studentai[i];
                    Studentai[i] = c;
                }
            }
        }
    }
}
