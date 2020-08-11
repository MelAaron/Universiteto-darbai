using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoNuoma.Models
{
    public class Mokinys
    {
        [DisplayName("Vardas")]
        [MaxLength(10)]
        [Required]
        public string vardas { get; set; }
        [DisplayName("Pavardė")]
        [MaxLength(20)]
        [Required]
        public string pavarde { get; set; }
        [DisplayName("Gimimo data")]
        [MaxLength(20)]
        [Required]
        public DateTime gimimo_data { get; set; }
        [DisplayName("Asmens Kodas")]
        [MaxLength(20)]
        [Required]
        public string asmens_kodas { get; set; }
        [DisplayName("Telefonas")]
        [MaxLength(10)]
        [Required]
        public string telefonas { get; set; }
        [DisplayName("El. pastas")]
        [MaxLength(10)]
        [Required]
        public string el_pastas { get; set; }
        [DisplayName("Adresas")]
        [MaxLength(10)]
        [Required]
        public string adresas { get; set; }
        [DisplayName("Lytis")]
        [MaxLength(10)]
        [Required]
        public string lytis { get; set; }
    }
}