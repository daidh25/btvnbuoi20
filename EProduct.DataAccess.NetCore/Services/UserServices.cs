
using EBook.DataAccess.NetCore.DBContext;
using EProduct.DataAccess.NetCore.DTO;
using EProduct.DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProduct.DataAccess.NetCore.Services
{
    public class UserServices : IUserServices
    {
        EProductDbContext _eProductDBContext = new EProductDbContext();


        public async Task<List<Users>> UsersGetList()
        {
            try
            {
                return _eProductDBContext.users.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<UsersInsertReturnData> UsersInsertUpdate(UsersInsertUpdateRequestData requestdata)
        {
            var returnData = new UsersInsertReturnData();
            var errItem = string.Empty;
            try
            {
                if (requestdata == null
                    || requestdata.OrderID == 0
                    || string.IsNullOrEmpty(requestdata.UserName)
                    || string.IsNullOrEmpty(requestdata.OrderValues))
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Dữu liệu không hợp lệ";
                    return returnData;
                }
                if (!EShop.Common.ValidationData.CheckContainSpecialChar(requestdata.UserName))
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "tên đăng nhập không hợp lệ";
                    return returnData;
                }

                var user = _eProductDBContext.users.Where(s => s.Username == requestdata.UserName).FirstOrDefault();
                if (user != null || user.UserID > 0)
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMsg = "Tên đăng nhập đã tồn tại";
                    return returnData;
                }

                var userReq = new Users
                {
                    Username = requestdata.UserName,
                    Password = requestdata.Password,
                    Email = requestdata.Email,

                };

                _eProductDBContext.users.Add(userReq);

                var attr_count = requestdata.OrderValues.Split('_').Length;

                for (int i = 0; i < attr_count; i++)
                {
                    var item = requestdata.OrderValues.Split('_')[i];

                    var attr_username = item.Split(',')[0];
                    var attr_password = item.Split(',')[1];

                    var attr_email = item.Split(',')[2];

                    if (string.IsNullOrEmpty(attr_username))
                    {
                        errItem += "tên đăng nhập bị trống hoặc không hợp lệ ";
                        continue;
                    }

                    if (string.IsNullOrEmpty(attr_password))
                    {
                        errItem += "password nhập bị trống hoặc không hợp lệ";
                        continue;
                    }

                    if (string.IsNullOrEmpty(attr_email))
                    {
                        errItem += " email nhập bị trống hoặc không hợp lệ";
                        continue;
                    }

                    var attr_Req = new OrderDetails
                    {
                        OrderID = requestdata.OrderID,
                        
                    };

                    _eProductDBContext.Add(attr_Req);

                }

                _eProductDBContext.SaveChangesAsync();


                returnData.ReturnCode = 1;
                returnData.ReturnMsg = "Thêm  thành công";
                return returnData;
            }
            catch (Exception ex)
            {

                returnData.ReturnCode = -969;
                returnData.ReturnMsg = "Hệ thống đang bận!";
                return returnData;
            }
        }
    }
}
