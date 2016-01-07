using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegulesViaje.Models
{
    public abstract class User
    {
        public User() 
        {
            UserGroups = new HashSet<UserGroup>();
        }

        public int Id { get; set; }

        public int IdentificationTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string IdentificationValue { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string SecondName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstLastName { get; set; }

        [Required]
        [StringLength(50)]
        public string SecondLastName { get; set; }

        [Required]
        public DateTime EntryDate { get; set; }

        public string Phone { get; set; }

        public string CellPhone { get; set; }

        public int CountryId { get; set; }

        public int DepartmentId { get; set; }

        public int LocationId { get; set; }

        public int NeighborhoodId { get; set; }

        public virtual IdentificationType IdentificationType { get; set; }
        public virtual Country Country { get; set; }
        public virtual Department Department { get; set; }
        public virtual Location Location { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }

        [StringLength(128)]
        public string Address { get; set; }

        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string eMail { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstLastName + " " + SecondLastName + ", " + FirstName + " " + SecondName;
            }
        }

        public virtual ICollection<UserGroup> UserGroups { get; set; }

    }

}
