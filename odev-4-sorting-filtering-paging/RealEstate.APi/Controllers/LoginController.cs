using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RealEstate.Model;
using RealEstate.Service;

namespace RealEstate.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;
        private readonly IRealEstateOwnerService realEstateOwnerService;

        public LoginController(IMemoryCache _memoryCache, IRealEstateOwnerService _realEstateOwnerService)
        {
            memoryCache = _memoryCache;
            realEstateOwnerService = _realEstateOwnerService;

        }

        [HttpPost]
        public General<bool> Login([FromBody] LoginModel loginUser)
        {
            General<bool> response = new() { Entity = false };
            General<RealEstateOwnerViewModel> result = realEstateOwnerService.Login(loginUser);

            if (!memoryCache.TryGetValue("LoginUser", out RealEstateOwnerViewModel _loginUser))
            {
                memoryCache.Set("LoginUser", result.Entity);
            }

            response.Entity = true;

            return response;
        }
    }
}

