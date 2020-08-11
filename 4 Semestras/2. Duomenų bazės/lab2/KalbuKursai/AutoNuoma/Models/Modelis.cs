using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AutoNuoma.Models
{
    public class Modelis
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Pavadinimas")]
        public string pavadinimas { get; set; }
        //Markė
        [DisplayName("Markė")]
        public virtual Marke marke { get; set; }

    }
}