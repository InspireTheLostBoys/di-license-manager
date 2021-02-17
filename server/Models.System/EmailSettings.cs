using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.System
{
    [Table("EmailSettings")]
    public class EmailSettings
    {

        [Key]
        public int ID { get; set; }

        public int LicenseExpiresInXMonths { get; set; }

    }
}
