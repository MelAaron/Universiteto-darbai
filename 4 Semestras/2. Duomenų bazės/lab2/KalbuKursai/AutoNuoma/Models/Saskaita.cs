using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoNuoma.Models
{
    public class Saskaita
    {
        public int nr { get; set; }
        public DateTime data { get; set; }
        public int fk_sutartis { get; set; }
        public double suma { get; set; }
    }
}