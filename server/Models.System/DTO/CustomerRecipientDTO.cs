using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.System.DTO
{
    public class CustomerRecipientDTO : BaseResponse.BaseResponseDTO
    {
        
        public int Id { get; set; }
       
        public int CustomerId { get; set; }
        
        public string SiteName { get; set; }

    }
}
