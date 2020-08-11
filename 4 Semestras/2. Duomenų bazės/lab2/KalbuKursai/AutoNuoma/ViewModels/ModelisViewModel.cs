using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AutoNuoma.ViewModels
{
    public class ModelisViewModel
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Pavadinimas")]
        public string pavadinimas { get; set; }
        [DisplayName("Markė")]
        public string marke { get; set; }

    }
}