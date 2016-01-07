using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class Neighborhood
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Barrio")]
        public string Name { get; set; }

        [Required]
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }

    }
}
