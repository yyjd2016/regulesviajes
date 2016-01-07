using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class Service
    {
        public Service() 
        {
            ServiceProperties = new HashSet<ServiceProperty>();
            Vouchers = new HashSet<Voucher>();
        }
        
        public int Id { get; set; }

        public int Order { get; set; }

        public int PeopleCount { get; set; }

        [Required]
        public int PackageId { get; set; }

        [Required]
        public int ProviderId { get; set; }

        public virtual Package Package { get; set; }
        public virtual Provider Provider { get; set; }

        public virtual ICollection<Voucher> Vouchers { get; set; }
        public virtual ICollection<ServiceProperty> ServiceProperties { get; set; }

    }
}
