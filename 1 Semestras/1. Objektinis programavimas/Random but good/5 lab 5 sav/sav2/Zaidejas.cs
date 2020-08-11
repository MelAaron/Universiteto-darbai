using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sav2
{
    abstract class Zaidejas
    {
        public string KomandosPavadinimas { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; } 
        public DateTime GimimoData { get; set; }    
        public int ZaistosRungtynes { get; set; }   
        public int Taskai { get; set; }

        public Zaidejas()
        {

        }
        public Zaidejas(string komandospavadinimas, string vardas, string pavarde, DateTime gimimodata, int zaistosrungtynes , int taskai)
        {
            KomandosPavadinimas = komandospavadinimas;
            Vardas = vardas;
            Pavarde = pavarde;
            GimimoData = gimimodata;
            ZaistosRungtynes = zaistosrungtynes;
            Taskai = taskai;
        }
        public Zaidejas(string data)
        {
            SetData(data);
        }
        public virtual void SetData(string line)
        {
            string[] values = line.Split(';');
            KomandosPavadinimas = values[1];
            Vardas = values[2];
            Pavarde = values[3];
            GimimoData =  DateTime.Parse(values[4]);
            ZaistosRungtynes = int.Parse(values[5]);
            Taskai = int.Parse(values[6]);
        }
        public override string ToString()
        {
            return String.Format("{0,-10} {1,-11} {2,-11} {3,10} {4,4} {5,5}", KomandosPavadinimas, Vardas, Pavarde, GimimoData.ToString("dd/MM/yyyy"), ZaistosRungtynes, Taskai);
        }
        public override int GetHashCode()
        {
            return Taskai.GetHashCode() ;
        }
        public static bool operator <=(Zaidejas lhs, double rhs)
        {
            return lhs.Taskai <= rhs;
        }
        public static bool operator >=(Zaidejas lhs, double rhs)
        {
            return lhs.Taskai >= rhs;
        }
    }
}
