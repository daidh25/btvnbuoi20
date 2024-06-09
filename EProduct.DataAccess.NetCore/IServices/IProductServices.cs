using EProduct.DataAccess.NetCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProduct.DataAccess.NetCore.IServices
{
    public interface IProductServices
    {
        Task<List<Product>> ProductGetList();
        Task<ProductInsertReturnData> ProductInsertUpdate(ProductInsertUpdateRequestData requestData);
        Task<ProductInsertReturnData> ProductEdit(ProductInsertUpdateRequestData requestData);
        Task<ProductInsertReturnData> ProductDelete(ProductInsertUpdateRequestData requestData);
    }
}
