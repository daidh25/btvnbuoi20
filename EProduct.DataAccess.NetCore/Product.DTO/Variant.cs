using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProduct.DataAccess.NetCore.DTO
{
    public class Variant
    {
       public int VariantID { get; set; }
       public int AttributeID {  get; set; } 
       public int GroupAttributeID { get; set; }
       public int AttributeName {  get; set; }
       public int Price { get; set; }
       public int PriceSale { get; set; }
       public int Quantity { get; set; }
    }
}
