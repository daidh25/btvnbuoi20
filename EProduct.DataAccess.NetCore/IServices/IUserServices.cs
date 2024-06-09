using EProduct.DataAccess.NetCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProduct.DataAccess.NetCore.IServices
{
    public interface IUserServices
    {
        Task<List<Users>> UsersGetList();
        Task<UsersInsertReturnData> UsersInsertUpdate(UsersInsertUpdateRequestData requestdata);
    }
}
