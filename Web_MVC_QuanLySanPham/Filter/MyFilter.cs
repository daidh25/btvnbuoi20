using Microsoft.AspNetCore.Mvc.Filters;

namespace Web_MVC_QuanLySanPham.Filter
{
    public class MyFilterAttribute : ActionFilterAttribute
    {
        public MyFilterAttribute()
        {
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var text = "";
            var router = filterContext.RouteData;
        }

    }
}
