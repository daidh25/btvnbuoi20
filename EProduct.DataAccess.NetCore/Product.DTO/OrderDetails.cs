using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProduct.DataAccess.NetCore.DTO
{
    public class OrderDetails
    {
        public int OrderDetailID {  get; set; }
        public int OrderID {  get; set; }
        public int ProductID {  get; set; }
        public string Quantity {  get; set; }
        public int Price { get; set; }
    }
}
