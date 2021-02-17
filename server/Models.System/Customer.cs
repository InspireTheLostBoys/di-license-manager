using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.System
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string EmailAdress { get; set; }
        [Required]
        [MaxLength(250)]
        public string AdressLine1 { get; set; }
        [Required]
        [MaxLength(250)]
        public string AdressLine2 { get; set; }
        [Required]
        [MaxLength(100)]
        public int City { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProvinceOrState { get; set; }
        [Required]
        [MaxLength(15)]
        public string PostalCode { get; set; }

        public DateTime DateTime { get; set; }

    }
}
