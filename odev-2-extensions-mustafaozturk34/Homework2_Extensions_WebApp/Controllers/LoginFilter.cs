using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;

namespace Homework2_Extensions_WebApp.Filter
{
    public class LoginFilter : Attribute, IActionFilter
    {
        string[] userType = Extensions.Extensions.GetEnumDisplay(Extensions.UserType.UserType4).Split("-");
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "SuccessfulTransaction" }));
        }


        //Metoda girmeden yapılacak işlemler
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.HttpContext.GetRouteData().Values["action"].ToString();
            if (action == "AdminPanel" && userType[1] != "Manager")
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "Error" }));
            }
            else if(action == "WorkerPanel" && userType[1] == "Consumer")
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "Error" }));
            }
            else if (action == "SellerPanel" && userType[0] == "Customer")
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "Error" }));
            }
        }
    }
}
