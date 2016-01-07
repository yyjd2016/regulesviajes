using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class Voucher
    {
        public Voucher() 
        {
            VoucherProperties = new HashSet<VoucherProperty>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        public virtual ICollection<VoucherProperty> VoucherProperties { get; set; }
    }
}
