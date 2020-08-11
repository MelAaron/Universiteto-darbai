using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AutoNuoma.ViewModels
{
    public class MiestasViewModel
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Pavadinimas")]
        public string pavadinimas { get; set; }
        [DisplayName("Šalis")]
        public string salis { get; set; }
    }
}