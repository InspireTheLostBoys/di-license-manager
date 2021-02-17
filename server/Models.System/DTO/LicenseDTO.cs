using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.System.DTO
{
    public class LicenseDTO : BaseResponse.BaseResponseDTO
    {
        public int ID { get; set; }

        public int SiteId { get; set; }

        public int ProductId { get; set; }

        public string CustomerName { get; set; }

        public DateTime DateTime { get; set; }
    }
}
