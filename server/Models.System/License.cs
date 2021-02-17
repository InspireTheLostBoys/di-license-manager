using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.System
{
    [Table("License")]
    public class License
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int SiteID { get; set; }

        [Required]
        public int AdminUserID { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public string Notes { get; set; }


        //links

        public virtual Product Product { get; set; }

        public virtual Site Site { get; set; }

        public virtual AdminUser AdminUser { get; set; }

    }
}
