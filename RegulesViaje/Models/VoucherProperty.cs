using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class VoucherProperty
    {
        [Key]
        [Column(Order = 0)]
        public int VoucherId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int PropertyId { get; set; }

        public virtual Voucher Voucher { get; set; }
        public virtual Property Property { get; set; }
    }
}
