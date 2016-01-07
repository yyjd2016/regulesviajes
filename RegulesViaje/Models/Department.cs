using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class Department
    {
        public Department() 
        {
            Locations = new HashSet<Location>();
            Users = new HashSet<User>();
            Providers = new HashSet<Provider>();
        }
        
        public int Id { get; set; }

        [Required]
        [Display(Name="Departamento")]
        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }

    }
}
