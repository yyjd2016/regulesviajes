using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class Location
    {
        public Location() 
        {
            Neighborhoods = new HashSet<Neighborhood>();
            Users = new HashSet<User>();
            Providers = new HashSet<Provider>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name="Localidad")]
        public string Name { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Neighborhood> Neighborhoods { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }
    }
}
