using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EProduct.DataAccess.NetCore.DTO;
using ProductInsertUpdateRequestData = EProduct.DataAccess.NetCore.DTO.ProductInsertUpdateRequestData;
using Web_MVC_QuanLySanPham.Models.Product;

namespace Web_MVC_QuanLySanPham.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id)
        {
            var model = new List<ProductModel>();
            for (int i = 0; i < 5; i++)
            {
                model.Add(new ProductModel
                {
                    ProductID = i + 1,
                    ProductName = "Product thứ " + (i + 1),

                });
            }
            return View(model);
        }

        public ActionResult Test()
        {
            var model = new List<ProductModel>();
            for (int i = 0; i < 5; i++)
            {
                model.Add(new ProductModel
                {
                    ProductID = i + 1,
                    CategoryID = i + 1,
                    ProductName = "Product thứ:  " + (i + 1)

                });
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult DemoLoadAjaxView()
        {
            var model = new List<ProductModel>();
            model = GetProduct();

            return PartialView(model);
        }

        public async Task<JsonResult> SaveProduct(ProductInsertUpdateRequestData requestData)
        {
            var model = new ProductInsertUpdateResponse();
            try
            {
                if (requestData == null
                    || string.IsNullOrEmpty(requestData.ProductName))
                {
                    model.ResponseCode = -1;
                    model.ResponseMessage = "Dữ liệu không được trống";
                    return Json(model);
                }

                var rs = await new EProduct.DataAccess.NetCore.Services.ProductServices().ProductInsertUpdate(requestData);


                model.ResponseCode = rs.ReturnCode;
                model.ResponseMessage = rs.ReturnMsg;
                return Json(model);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private List<ProductModel> GetProduct()
        {
            var model = new List<ProductModel>();
            for (int i = 0; i < 5; i++)
            {
                model.Add(new ProductModel
                {
                    ProductID = i + 1,
                    CategoryID = i + 1,
                    ProductName = "Product thứ:  " + (i + 1)
                });
            }

            return model;
        }

    }

}