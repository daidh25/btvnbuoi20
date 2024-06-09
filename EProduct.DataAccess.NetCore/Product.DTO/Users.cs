using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProduct.DataAccess.NetCore.DTO
{
    public class Users
    {
            public int UserID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
    }
}
