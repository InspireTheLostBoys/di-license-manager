using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.System.DTO
{
    public class RecipientDTO : BaseResponse.BaseResponseDTO
    {

        public int ID { get; set; }

        public int SiteID { get; set; }

        public string RecipientName { get; set; }

        public string EmailAddress { get; set; }

        public SiteDTO Site { get; set; }

    }
}
