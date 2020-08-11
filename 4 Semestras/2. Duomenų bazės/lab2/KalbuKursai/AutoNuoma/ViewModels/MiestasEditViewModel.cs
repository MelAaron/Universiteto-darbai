using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoNuoma.ViewModels
{
    public class MiestasEditViewModel
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Pavadinimas")]
        [MaxLength(20)]
        [Required]
        public string pavadinimas { get; set; }
        [DisplayName("Šalis")]
        [Required]
        public string salis { get; set; }

        //Markiu sąrašas pasirinkimui
        //public IList<SelectListItem> MarkesList { get; set; }
    }
}