using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoNuoma.Models
{
    public class Sutartis
    {
        [DisplayName("NR")]
        public int nr { get; set; }
        [DisplayName("Sutarties data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime sutarties_data { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Pradžios data")]
        public DateTime pradzios_data { get; set; }
        [DisplayName("Būsena")]
        public string busena { get; set; }
        [DisplayName("Mokykla")]
        public string fk_mokykla { get; set; }
        [DisplayName("Mokinys")]
        public string fk_mokinys { get; set; }
    }
}