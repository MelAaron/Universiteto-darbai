using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoNuoma.Models
{
    public class Mokytojas
    {
        [DisplayName("Vardas")]
        [Required]
        public string vardas { get; set; }
        [DisplayName("Pavardė")]
        [Required]
        public string pavarde { get; set; }
        [DisplayName("Amzius")]
        [Required]
        public int amzius { get; set; }
        [DisplayName("Asmens Kodas")]
        [Required]
        public string asmens_kodas { get; set; }
        [DisplayName("Lytis")]
        [Required]
        public string lytis { get; set; }
        [DisplayName("Specializacija")]
        [Required]
        public string specializacija { get; set; }
        [DisplayName("Mokykla")]
        [Required]
        public string mokykla { get; set; }
    }
}