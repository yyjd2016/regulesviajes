using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class ConvertionRate
    {
        public ConvertionRate() 
        {
            Packages = new HashSet<Package>();
        }
        
        public int Id { get; set; }

        [Required]
        public double PurchaseValue { get; set; }

        [Required]
        public double SaleValue { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CurrencyOneId { get; set; }

        [Required]
        public int CurrencyTwoId { get; set; }

        public virtual Currency CurrencyOne { get; set; }

        public virtual Currency CurrencyTwo { get; set; }

        public virtual ICollection<Package> Packages { get; set; }

    }
}
