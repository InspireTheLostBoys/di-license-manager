﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.System
{
    [Table("EmailSettings")]
    public class EmailSetting
    {
        [Key]
        public int ID { get; set; }


        [Required]
        public int LicenseExpiresInXMonths { get; set; }
    }
}
