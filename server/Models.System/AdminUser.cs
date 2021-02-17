using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.System
{
    [Table("AdminUser")]
    public class AdminUser
    {
        [Key]
        public int ID { get; set; }


        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }


        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }


        [Required]
        [MaxLength(500)]
        public string EmailAddress { get; set; }


        [Required]
        [MaxLength(100)]
        public string Password { get; set; }


        [Required]
        public bool Active { get; set; }


        public DateTime? LastLoggedInDateTime { get; set; }         // the ? means not required 

    }
}
