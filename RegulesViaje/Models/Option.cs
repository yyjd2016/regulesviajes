using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class Option
    {
        public Option()
        {
            Securities = new HashSet<Security>();
        }

        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Security> Securities { get; set; }

    }
}
