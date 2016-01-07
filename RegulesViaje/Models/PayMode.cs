using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class PayMode
    {
        public PayMode() 
        {
            PackagePayModes = new HashSet<PackagePayMode>();
        }
        
        public int Id { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(128)]
        public string Description { get; set; }

        public virtual ICollection<PackagePayMode> PackagePayModes { get; set; }
    }
}
