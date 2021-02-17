using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.System
{
    [Table("Car")]
    public class Car
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
    }
}
