using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace ModelsContinued.Controllers
{
    public class LoginRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // how might this be usefull??
            // if(context.HttpContext.Session.GetInt32("id") == null)
            
        }
    }
}