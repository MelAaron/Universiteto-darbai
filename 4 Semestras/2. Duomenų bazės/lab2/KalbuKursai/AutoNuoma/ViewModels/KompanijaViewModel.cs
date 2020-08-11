using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AutoNuoma.ViewModels
{
    public class KompanijaViewModel
    {
        [DisplayName("Pavadinimas")]
        public string pavadinimas { get; set; }
        [DisplayName("Telefonas")]
        public string telefonas { get; set; }
        [DisplayName("El paštas")]
        public string el_pastas { get; set; }
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Miestas")]
        public string fk_miestas { get; set; }
    }
}