using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoNuoma.Models;


namespace AutoNuoma.ViewModels
{
    public class SutartisEditViewModel
    {
        [DisplayName("Sutarties nr.")]
        [Required]
        public int nr { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        [DisplayName("Sutarties data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime sutarties_data { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        [DisplayName("Pradžios data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime pradzios_data { get; set; }
        [DisplayName("Būsena")]
        [Required]
        public string busena { get; set; }
        [DisplayName("Mokykla")]
        [Required]
        public string fk_mokykla { get; set; }
        [DisplayName("Mokinys")]
        [Required]
        public string fk_mokinys { get; set; }
        //Užsakytų papildomų paslaugų sąrašas
        public virtual List<Saskaita> saskaitos {get;set;}

        //Sąrašai skirti sugeneruoti pasirinkimams
        public IList<SelectListItem> MokyklosList { get; set; }
        public IList<SelectListItem> MokiniaiList { get; set; }
        public IList<SelectListItem> busenos { get; set; }
    }
}