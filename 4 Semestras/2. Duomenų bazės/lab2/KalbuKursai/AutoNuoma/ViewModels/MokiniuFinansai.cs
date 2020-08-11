using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoNuoma.ViewModels
{
    public class MokiniuFinansai
    {
        public List<MokiniuFinansai2> mokiniai { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? nuo { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? iki { get; set; }
        public decimal? kainaNuo { get; set; }
        public decimal? kainaIki { get; set; }
        public decimal? sumokejoNuo { get; set; }
        public decimal? sumokejoIki { get; set; }


        public decimal visoSuma { get; set; }
        public decimal visoSumoketa { get; set; }
        public int lankomuKursuK { get; set; }
    }

    public class MokiniuFinansai2
    {
        public string mokinio_vardas { get; set; }
        public decimal pilna_kaina { get; set; }
        public decimal sumokejo { get; set; }
        public string Skola { get; set; }
        public int kursu_kiekis { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime sutarties_data { get; set; }
        public int sutarties_nr { get; set; }
    }
}