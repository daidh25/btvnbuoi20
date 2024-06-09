using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProduct.DataAccess.NetCore.DTO
{
    public class UsersInsertUpdateRequestData
    {
        public int UserID { get; set; }
        public int OrderID { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string OrderValues { get; set; }
    }
}
