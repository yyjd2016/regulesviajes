using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class Country
    {
        public Country()
        {
            Departments = new HashSet<Department>();
            Users = new HashSet<User>();
            Providers = new HashSet<Provider>();
        }
        
        public int Id { get; set; }

        [Required]
        [Display(Name="País")]
        public string Name { get; set; }

        // Para la relacion con los modelos del estremo muchos
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }



    }
}
