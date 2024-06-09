using EBook.DataAccess.NetCore.DBContext;
using EProduct.DataAccess.NetCore.SinhVienDTO;
using Microsoft.AspNetCore.Mvc;
using EProduct.DataAccess.NetCore.Services;
using EProduct.DataAccess.NetCore.DTO;

namespace Web_MVC_QuanLySanPham.Controllers
{
    public class StudentController : Controller
    {
        private readonly EStudentDbContext _context;
        private readonly IConfiguration _configuration;

        public StudentController(EStudentDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [ActionName("idx")]
        [HttpGet]
        [HttpPost]
        public ActionResult Index()
        {
            var myconection = _configuration["URL:myUrl"] ?? "";
            return View(myconection);
        }

        [HttpPost]
        [MyCustomAuthentication("Test_Filter1124", "VIEW")]
        public JsonResult Test_Filter()
        {
            var returndata = new ReturnData();
            return Json(returndata);
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("StudentList");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult StudentList()
        {
            var students = _context.Students.ToList();
            return View(students);
        }
    }
}
