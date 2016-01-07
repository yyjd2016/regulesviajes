﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class IdentificationType
    {
        public IdentificationType() 
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
