using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class PackagePayMode
    {
        [Key]
        [Column(Order = 0)]
        public int PackageId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int PayModeId { get; set; }

        public double Amount { get; set; }

        public virtual Package Package { get; set; }
        public virtual PayMode PayMode { get; set; }
    }
}
