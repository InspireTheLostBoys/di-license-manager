using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.System.DTO
{
    public class CustomerDTO
    {
        
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public string EmailAddress { get; set; }
        
        public string AddressLine1 { get; set; }
        
        public string AddressLine2 { get; set; }
        
        public string City { get; set; }
       
        public string ProvinceOrState { get; set; }
        
        public int PostalCode { get; set; }

        public DateTime DateTime { get; set; }
    }
}
