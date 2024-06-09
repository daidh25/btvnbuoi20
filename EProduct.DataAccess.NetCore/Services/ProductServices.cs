
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
    public class ProductServices : IProductServices
    {
        EProductDbContext _eProductDBContext = new EProductDbContext();

       
        public async Task<List<Product>> ProductGetList()
        {
            try
            {
                return _eProductDBContext.product.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<ProductInsertReturnData> ProductInsertUpdate(ProductInsertUpdateRequestData requestData)
        {
            var returnData = new ProductInsertReturnData();
            var errItem = string.Empty;
            try
            {
                if (requestData == null
                    || requestData.CategoryID == 0
                    || string.IsNullOrEmpty(requestData.ProductName)
                    || string.IsNullOrEmpty(requestData.AttributeValues))
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Dữu liệu không hợp lệ";
                    return returnData;
                }
                if (!EShop.Common.ValidationData.CheckContainSpecialChar(requestData.ProductName))
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "tên sản phẩm không hợp lệ";
                    return returnData;
                }

                var product = _eProductDBContext.product.Where(s => s.ProductName == requestData.ProductName).FirstOrDefault();
                if (product != null || product.ProductID > 0)
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMsg = "Tên sản phẩm đã tồn tại";
                    return returnData;
                }

                var productReq = new Product
                {
                    ProductName = requestData.ProductName,
                    CategoryID = requestData.CategoryID
                };

                _eProductDBContext.product.Add(productReq);

                var attr_count = requestData.AttributeValues.Split('_').Length;

                for (int i = 0; i < attr_count; i++)
                {
                    var item = requestData.AttributeValues.Split('_')[i];

                    var attr_name = item.Split(',')[0];
                    var attr_quantity = item.Split(',')[1];

                    var attr_price = item.Split(',')[2];
                    var attr_priceSale = item.Split(',')[3];
                    if (string.IsNullOrEmpty(attr_name))
                    {
                        errItem += "tên thuộc tính bị trống hoặc không hợp lệ ";
                        continue;
                    }

                    if (string.IsNullOrEmpty(attr_quantity))
                    {
                        errItem += "thuộc tính số lượng bị trống";
                        continue;
                    }

                    if (string.IsNullOrEmpty(attr_price))
                    {
                        errItem += " thuộc tính giá bị trống";
                        continue;
                    }

                    if (string.IsNullOrEmpty(attr_priceSale))
                    {
                        errItem += " thuộc tính giá sale bị trống";
                        continue;
                    }

                    var attr_Req = new ProductAttribute
                    {
                        AttributeName = attr_name,
                        Quantity = attr_quantity,
                        Price = Convert.ToInt32(attr_price),
                        PriceSale = Convert.ToInt32(attr_priceSale),
                    };

                    _eProductDBContext.Add(attr_Req);

                }

                _eProductDBContext.SaveChangesAsync();


                returnData.ReturnCode = 1;
                returnData.ReturnMsg = "Thêm sản phẩm thành công";
                return returnData;
            }
            catch (Exception ex)
            {

                returnData.ReturnCode = -969;
                returnData.ReturnMsg = "Hệ thống đang bận!";
                return returnData;
            }
        }
        public async Task<ProductInsertReturnData> ProductEdit(ProductInsertUpdateRequestData requestData)
        {
            var returnData = new ProductInsertReturnData();
            try
            {
                if (requestData == null
                    || requestData.ProductID == 0
                    || requestData.CategoryID == 0
                    || string.IsNullOrEmpty(requestData.ProductName)
                    || string.IsNullOrEmpty(requestData.AttributeValues))
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Dữ liệu không hợp lệ";
                    return returnData;
                }

                var product = await _eProductDBContext.product.FindAsync(requestData.ProductID);
                if (product == null)
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMsg = "Sản phẩm không tồn tại";
                    return returnData;
                }

                product.ProductName = requestData.ProductName;
                product.CategoryID = requestData.CategoryID;

                var existingAttributes = _eProductDBContext.productattribute.Where(pa => pa.AttributeID == requestData.AttributeID);
                _eProductDBContext.productattribute.RemoveRange(existingAttributes);

                var attr_count = requestData.AttributeValues.Split('_').Length;

                for (int i = 0; i < attr_count; i++)
                {
                    var item = requestData.AttributeValues.Split('_')[i];

                    var attr_name = item.Split(',')[0];
                    var attr_quantity = item.Split(',')[1];
                    var attr_price = item.Split(',')[2];
                    var attr_priceSale = item.Split(',')[3];
                    if (string.IsNullOrEmpty(attr_name))
                    {
                        returnData.ReturnCode = -1;
                        returnData.ReturnMsg = "Tên thuộc tính bị trống hoặc không hợp lệ";
                        return returnData;
                    }

                    if (string.IsNullOrEmpty(attr_quantity))
                    {
                        returnData.ReturnCode = -1;
                        returnData.ReturnMsg = "Thuộc tính số lượng bị trống";
                        return returnData;
                    }

                    if (string.IsNullOrEmpty(attr_price))
                    {
                        returnData.ReturnCode = -1;
                        returnData.ReturnMsg = "Thuộc tính giá bị trống";
                        return returnData;
                    }

                    if (string.IsNullOrEmpty(attr_priceSale))
                    {
                        returnData.ReturnCode = -1;
                        returnData.ReturnMsg = "Thuộc tính giá sale bị trống";
                        return returnData;
                    }

                    var attr_Req = new ProductAttribute
                    {
                        AttributeName = attr_name,
                        Quantity = attr_quantity,
                        Price = Convert.ToInt32(attr_price),
                        PriceSale = Convert.ToInt32(attr_priceSale),
                    };

                    _eProductDBContext.productattribute.Add(attr_Req);
                }

                await _eProductDBContext.SaveChangesAsync();

                returnData.ReturnCode = 1;
                returnData.ReturnMsg = "Cập nhật sản phẩm thành công";
                return returnData;
            }
            catch (Exception ex)
            {
                returnData.ReturnCode = -969;
                returnData.ReturnMsg = "Hệ thống đang bận!";
                return returnData;
            }
        }


        public async Task<ProductInsertReturnData> ProductDelete(ProductInsertUpdateRequestData requestData)
        {
            var returnData = new ProductInsertReturnData();
            try
            {
                if (requestData == null || requestData.ProductID == 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Dữ liệu không hợp lệ";
                    return returnData;
                }

                var product = await _eProductDBContext.product.FindAsync(requestData.ProductID);
                if (product == null)
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMsg = "Sản phẩm không tồn tại";
                    return returnData;
                }

                var productAttributes = _eProductDBContext.product.Where(pa => pa.ProductID == requestData.ProductID).ToList();
                _eProductDBContext.productattribute.RemoveRange();

                _eProductDBContext.product.Remove(product);
                await _eProductDBContext.SaveChangesAsync();

                returnData.ReturnCode = 1;
                returnData.ReturnMsg = "Xóa sản phẩm thành công";
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
