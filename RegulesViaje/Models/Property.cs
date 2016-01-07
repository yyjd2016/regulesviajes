using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class Property
    {
        public Property() 
        {
            VoucherProperties = new HashSet<VoucherProperty>();
            ProviderProperties = new HashSet<ProviderProperty>();
            ServiceProperties = new HashSet<ServiceProperty>();
        } 

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string DisplayName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public short DataType { get; set; }

        [StringLength(100)]
        public string Source { get; set; }

        public virtual ICollection<VoucherProperty> VoucherProperties { get; set; }
        public virtual ICollection<ProviderProperty> ProviderProperties { get; set; }
        public virtual ICollection<ServiceProperty> ServiceProperties { get; set; }

    }
}
