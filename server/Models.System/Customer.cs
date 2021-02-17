using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.System
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(150)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(500)]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(250)]
        public string AddressLine1 { get; set; }

        [Required]
        [MaxLength(250)]
        public string AddressLine2 { get; set; }


        [Required]
        [MaxLength(100)]
        public string City { get; set; }


        [Required]
        [MaxLength(100)]
        public string ProvinceOrState { get; set; }


        [Required]
        [MaxLength(15)]
        public int PostalCode { get; set; }

    }
}
