using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.System
{
    [Table("Recipient")]
    public class Recipient
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int SiteID { get; set; }

        [Required]
        public string RecipientName { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public virtual Site Site { get; set; }
    }
}
