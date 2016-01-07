using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    /// <summary>
    /// Especialization of user class
    /// </summary>
    public class Client : User
    {
        public Client() : base()
        {
            Packages = new HashSet<Package>();
        }
        
        [StringLength(128)]
        public string EmergencyContact { get; set; }

        [StringLength(128)]
        public string FootRequirement { get; set; }

        [StringLength(128)]
        public string HealthRequirement { get; set; }

        [StringLength(128)]
        public string LifeInsurance { get; set; }

        public virtual ICollection<Package> Packages { get; set; }

    }
}
