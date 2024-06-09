using EProduct.DataAccess.NetCore.SinhVienDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProduct.DataAccess.NetCore.DTO
{
    public class ReturnData
    {
        public int ReturnCode { get; set; }
        public string ReturnMsg { get; set; }
    }

    public class ProductInsertReturnData : ReturnData
    {
        public Product product { get; set; }
    }
    public class ProductAttributeUpdateReturnData : ReturnData 
    {
        public ProductAttribute productattribute { get; set; }
    }
    public class UsersInsertReturnData : ReturnData
    {
        public Users users { get; set; }
    }
    public class StudentInsertReturnData : ReturnData
    {
        public Student student { get; set; }
    }

}
