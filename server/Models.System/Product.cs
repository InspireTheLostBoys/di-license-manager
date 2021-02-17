using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.System
{
    [Table("Product")]
    public class Product
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Supplier { get; set; }
        [Required]
        [MaxLength(150)]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(150)]
        public string ProductDescription { get; set; }
        [Required]
        [MaxLength(150)]
        public int ProductId { get; set; }

        public DateTime DateTime { get; set; }
    }
}
