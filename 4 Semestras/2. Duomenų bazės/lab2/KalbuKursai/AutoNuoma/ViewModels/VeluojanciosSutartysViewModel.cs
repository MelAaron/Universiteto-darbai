using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoNuoma.ViewModels
{
    public class VeluojanciosSutartysViewModel
    {
        [DisplayName("Sutartis")]
        public int nr { get; set; }

        public DateTime sutartiesData { get; set; }
        [DisplayName("Klientas")]
        public string mokinys { get; set; }
        [DisplayName("Planuota grąžinti")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime pradzios_data { get; set; }
    }
}