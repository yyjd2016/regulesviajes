using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class Currency
    {
        public Currency() 
        {
            RateOne = new HashSet<ConvertionRate>();
            RateTwo = new HashSet<ConvertionRate>();
            Packages = new HashSet<Package>();
        }

        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Code { get; set; }

        public string Symbol { get; set; }

        public virtual ICollection<ConvertionRate> RateOne { get; set; }
        public virtual ICollection<ConvertionRate> RateTwo { get; set; }
        public virtual ICollection<Package> Packages { get; set; }

    }
}
