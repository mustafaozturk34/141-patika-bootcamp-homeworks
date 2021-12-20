using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using ReaLEstate.Extension;
using System;

namespace RealEstate.APi.Infrastructer
{
    public class LoginFilter : Attribute, IActionFilter
    {
        //type1 = Arsa, type2 = Tarla

        string realEstateType = ReaLEstate.Extension.Extension.GetEnum(ReaLEstate.Extension.Enum.type1);

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
           if(realEstateType == "Arsa")
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "RealEstate", Action = "GetEstate" }));

            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
