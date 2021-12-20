using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RealEstate.Model;

namespace RealEstate.APi.Infrastructer
{
    public class BaseController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;
        public BaseController(IMemoryCache _memoryCache)
        {
            memoryCache = _memoryCache;
        }
        public RealEstateOwnerViewModel CurrentUser
        {
            get
            {
                return GetCurrentUser();
            }
        }

        private RealEstateOwnerViewModel GetCurrentUser()
        {
            var response = new RealEstateOwnerViewModel();

            if (memoryCache.TryGetValue("LoginUser", out RealEstateOwnerViewModel _loginUser))
            {
                response = _loginUser;
            }

            return response;
        }
    }
}
