using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoNuoma.ViewModels
{
    public class KompanijaEditViewModel
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Pavadinimas")]
        [Required]
        public string pavadinimas { get; set; }
        [DisplayName("Telefonas")]
        [Required]
        public string telefonas { get; set; }
        [DisplayName("El paštas")]
        [Required]
        public string el_pastas { get; set; }
        [DisplayName("Miestas")]
        [Required]
        public int fk_miestas { get; set; }
        public IList<SelectListItem> MiestaiList { get; set; }
    }
}