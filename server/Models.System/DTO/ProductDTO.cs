using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.System.DTO
{
    public class ProductDTO : BaseResponse.BaseResponseDTO
    {

        public int Id { get; set; }

        public string Supplier { get; set; }
        
        public string ProductName { get; set; }
       
        public string ProductDescription { get; set; }
        
        public int ProductId { get; set; }

        public DateTime DateTime { get; set; }
    }
}
