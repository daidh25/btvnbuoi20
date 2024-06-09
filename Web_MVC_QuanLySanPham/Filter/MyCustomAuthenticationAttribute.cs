using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Web_MVC_QuanLySanPham.Filter
{
    public class MyCustomAuthenticationAttribute : TypeFilterAttribute
    {
        public MyCustomAuthenticationAttribute(string function, string permision) :
            base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { function, permision };
        }
    }

    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        public string _function { get; set; }

        public string _permision { get; set; }

        public ClaimRequirementFilter(string function, string permision)
        {
            _function = function;
            _permision = permision;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var f = _function;
           
        }
    }
}
