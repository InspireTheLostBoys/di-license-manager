using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.System
{
    [Table("Site")]
    public class Site
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string SiteName { get; set; }

        [Required]
        public int CustomerID { get; set; }


        //this sets the link from site to customer.
        public virtual Customer Customer { get; set; }

        public object ToList()
        {
            throw new NotImplementedException();
        }
    }
}
