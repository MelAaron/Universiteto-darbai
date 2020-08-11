using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoNuoma.Models
{
    public class Mokykla
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
        [DisplayName("Kompanija")]
        [Required]
        public string fk_kompanija { get; set; }
        [DisplayName("Tinklalapis")]
        [Required]
        public string tinklalapis { get; set; }
        [DisplayName("Adresas")]
        [Required]
        public string adresas { get; set; }
    }
}