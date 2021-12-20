using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;
using RealEstate.Model;
using ReaLEstate.Extension;
using System;

namespace RealEstate.APi.Infrastructer
{
    public class LoginFilter : Attribute, IActionFilter
    {
        private readonly IMemoryCache memoryCache;
        public LoginFilter(IMemoryCache _memoryCache)
        {
            memoryCache = _memoryCache;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //var memoryCache = context.HttpContext.RequestServices.GetService<IMemoryCache>();

            if (!memoryCache.TryGetValue("LoginUser", out RealEstateOwnerViewModel _loginUser))
            {
                context.Result = new UnauthorizedObjectResult("Lütfen giriş yapınız");
            }
        }
    }
}
