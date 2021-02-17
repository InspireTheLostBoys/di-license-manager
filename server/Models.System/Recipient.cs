using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


        //this sets the link to sites. the recipient neesd a site.
        public virtual Site Site { get; set; }

    }
}
