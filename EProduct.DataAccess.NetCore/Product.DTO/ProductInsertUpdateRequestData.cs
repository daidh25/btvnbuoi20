using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProduct.DataAccess.NetCore.DTO
{
    public class ProductInsertUpdateRequestData
    {
        public int ProductID { get; set; }
        public int AttributeID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string AttributeValues { get; set; }
    }
    
}
