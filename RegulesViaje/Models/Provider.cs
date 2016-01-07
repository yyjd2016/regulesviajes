using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class Provider
    {
        public Provider() 
        {
            Services = new HashSet<Service>();
            ProviderProperties = new HashSet<ProviderProperty>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int ProviderClasificationId { get; set; }

        public int CountryId { get; set; }

        public int DepartmentId { get; set; }

        public int LocationId { get; set; }

        public int NeighborhoodId { get; set; }
        
        [StringLength(255)]
        public string Address { get; set; }

        public virtual ProviderClasification ProviderClasification { get; set; }
        public virtual Country Country { get; set; }
        public virtual Department Department { get; set; }
        public virtual Location Location { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }

        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<ProviderProperty> ProviderProperties { get; set; }

    }
}
