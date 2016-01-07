using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class Security
    {
        //public int Id { get; set; }

        public short Value { get; set; }

        [Key]
        [Column(Order = 0)]
        public int GroupId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ModuleId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int OptionId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Module Module { get; set; }
        public virtual Option Option  { get; set; }

    }
}
