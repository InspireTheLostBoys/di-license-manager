using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.System
{
    [Table("CustomerRecipient")]
    public class CustomerRecipient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(150)]
        public string SiteName { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
