using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoNuoma.Models
{
    public class Kursas
    {
        [DisplayName("Kalba")]
        [Required]
        public string kalba { get; set; }
        [DisplayName("Trukmė mėnesiais")]
        [Required]
        public int trukme_menesiais { get; set; }
        [DisplayName("Kaina")]
        [Required]
        public double kaina { get; set; }
        [DisplayName("ID")]
        [Required]
        public int id { get; set; }
        [DisplayName("Max Mokinių")]
        [Required]
        public int max_mokiniu { get; set; }
        [DisplayName("Mokymosi Medžiaga")]
        [Required]
        public string mokymosi_medziaga { get; set; }
        [DisplayName("Lygis")]
        [Required]
        public string lygis { get; set; }
        [DisplayName("Savaitės diena")]
        [Required]
        public string savaites_diena { get; set; }
        [DisplayName("Mokytojo asmens kodas")]
        [Required]
        public string mokytojo_asmens_kodas { get; set; }

        public IList<SelectListItem> MokytojaiList { get; set; }
        public IList<SelectListItem> lygiai { get; set; }
        public IList<SelectListItem> mokMedz { get; set; }
        public IList<SelectListItem> savDien { get; set; }
    }
}