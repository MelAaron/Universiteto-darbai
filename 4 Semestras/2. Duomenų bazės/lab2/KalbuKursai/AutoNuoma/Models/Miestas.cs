using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoNuoma.Models
{
    public class Miestas
    {
        [DisplayName("ID")]
        [MaxLength(10)]
        [Required]
        public int id { get; set; }
        [DisplayName("Pavadinimas")]
        [MaxLength(20)]
        [Required]
        public string pavadinimas { get; set; }

        //public virtual ICollection<Aikstele> Aiksteles { get; set; }
        [DisplayName("Šalis")]
        [MaxLength(20)]
        [Required]
        public string salis { get; set; }
    }
}