using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class Employed : User
    {
        public Employed() : base() 
        {
            Packages = new HashSet<Package>();
        }
        
        public double Salary { get; set; }

        public DateTime FinishDate { get; set; }

        public int StateId { get; set; }

        public virtual State State { get; set; }

        public virtual ICollection<Package> Packages { get; set; }

    }
}
