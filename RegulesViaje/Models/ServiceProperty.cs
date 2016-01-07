using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class ServiceProperty
    {
        [Key]
        [Column(Order=0)]
        public int ServiceId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int PropertyId { get; set; }

        [Required]
        [StringLength(255)]
        public string Value { get; set; }

        public virtual Service Service { get; set; }
        public virtual Property Property { get; set; }


    }
}
