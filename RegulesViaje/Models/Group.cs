using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace RegulesViaje.Models
{
    public class Group
    {
        public Group() 
        {
            Securities = new HashSet<Security>();
            UserGroups = new HashSet<UserGroup>();
        }
        
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Security> Securities { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }


    }
}
