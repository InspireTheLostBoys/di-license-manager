using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.System.DTO
{
    public class EmailSettingsDTO : BaseResponse.BaseResponseDTO
    {
        
        public int ID { get; set; }
        
        public int EveryXMonths { get; set; }
    }
}
