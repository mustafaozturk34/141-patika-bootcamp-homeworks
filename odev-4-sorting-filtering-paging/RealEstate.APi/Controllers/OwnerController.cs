using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.APi.Infrastructer;
using RealEstate.Model;
using RealEstate.Service;
using System.Collections.Generic;

namespace RealEstate.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IRealEstateOwnerService realEstateOwnerService;

        public OwnerController(IRealEstateOwnerService _realEstateOwnerService)
        {
            realEstateOwnerService = _realEstateOwnerService;
        }

        [HttpPost]
        [ServiceFilter(typeof(LoginFilter))]
        public General<RealEstateOwnerViewModel> Insert([FromBody] RealEstateOwnerViewModel newUser)
        {
            var result = false;
            return realEstateOwnerService.Insert(newUser);
        }

        [HttpPost("login")]
        public General<RealEstateOwnerViewModel> Login(LoginModel loginUser)
        {
            return realEstateOwnerService.Login(loginUser);
        }

        [HttpGet]
        public General<RealEstateOwnerViewModel> GetUsers()
        {
            return realEstateOwnerService.GetUsers();
        }

        [HttpPut("{id}")]
        public General<RealEstateOwnerViewModel> Update(int id, [FromBody] RealEstateOwnerViewModel user)
        {
            return realEstateOwnerService.Update(id, user);
        }

        [HttpDelete]
        public General<RealEstateOwnerViewModel> Delete(int id)
        {
            return realEstateOwnerService.Delete(id);
        }

    }
}

