using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoNuoma.Models
{
    public class Kompanija
    {
        [DisplayName("Pavadinimas")]
        [Required]
        public string pavadinimas { get; set; }
        [DisplayName("Telefonas")]
        [Required]
        public string telefonas { get; set; }
        [DisplayName("El paštas")]
        [Required]
        public string el_pastas { get; set; }
        [DisplayName("ID")]
        [Required]
        public int id { get; set; }
        [DisplayName("Miestas")]
        [Required]
        public Miestas fk_miestas { get; set; }
    }
}