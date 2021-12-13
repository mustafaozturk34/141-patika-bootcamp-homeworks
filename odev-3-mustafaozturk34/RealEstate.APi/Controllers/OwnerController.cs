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
        public General<RealEstateOwnerViewModel> Insert([FromBody] RealEstateOwnerViewModel newUser)
        {
            var result = false;
            return realEstateOwnerService.Insert(newUser);
        }

        [LoginFilter]
        [HttpPost("login")]
        public bool Login(string email, string password)
        {
            return realEstateOwnerService.Login(email, password);
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

