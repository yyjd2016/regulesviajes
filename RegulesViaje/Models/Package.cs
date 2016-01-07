using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class Package
    {
        public Package()
        {
            Services = new HashSet<Service>();
            PackagePayModes = new HashSet<PackagePayMode>();
        }
        
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int EmployedId { get; set; }
        public virtual Employed Employed { get; set; }

        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        public int StateId { get; set; }
        public virtual State State { get; set; }

        public int ConvertionRateId { get; set; }
        public virtual ConvertionRate ConvertionRate { get; set; }

        public virtual ICollection<PackagePayMode> PackagePayModes { get; set; }
        public virtual ICollection<Service> Services { get; set; }

    }
}
