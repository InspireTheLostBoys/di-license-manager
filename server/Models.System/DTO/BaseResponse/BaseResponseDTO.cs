using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.System.DTO.BaseResponse
{
   public class BaseResponseDTO
    {
        public bool Success { get; set; }
        public string ErrorHint { get; set; }
        public string FullException { get; set; }
    }
}
