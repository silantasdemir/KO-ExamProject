using KO.Entities;
using KO.Web.UI.MVC.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KO.Web.UI.MVC.CustomFilters
{
    public class MemberLoginFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var member = context.HttpContext.Session.GetObject<Member>("Member");

            if (member == null)
                context.Result = new RedirectResult("/Account/Login");
        }
    }
}
