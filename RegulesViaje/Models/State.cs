using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class State
    {
        public State() 
        {
            Employees = new HashSet<Employed>();
            Packages = new HashSet<Package>();
        }
        
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public virtual ICollection<Employed> Employees { get; set; }
        public virtual ICollection<Package> Packages { get; set; }

    }
}
