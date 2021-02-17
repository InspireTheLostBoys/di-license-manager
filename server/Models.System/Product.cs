using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.System
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ID { get; set; }


        [Required]
        public string ProductName { get; set; }


        [Required]
        public string ProductSupplier { get; set; }

    }
}
