﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulesViaje.Models
{
    public class UserGroup
    {
        //public int UserGroupId { get; set; }

        [Key]
        [Column(Order = 0)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int GroupId { get; set; }

        public virtual User User { get; set; }
        public virtual Group Group { get; set; }

    }
}
