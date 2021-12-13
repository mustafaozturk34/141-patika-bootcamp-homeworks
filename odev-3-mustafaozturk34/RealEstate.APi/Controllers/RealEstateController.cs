using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Model;
using RealEstate.Service;
using System.Collections.Generic;

namespace RealEstate.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly IRealEstateService realEstateService;

        public RealEstateController(IRealEstateService _realEstateService)
        {
            realEstateService = _realEstateService;
        }
        [HttpPost]
        public General<RealEstateViewModel> Insert([FromBody] RealEstateViewModel newRealEstate)
        {
            var result = false;
            return realEstateService.Insert(newRealEstate);
        }

        [HttpGet]
        public General<RealEstateViewModel> GetRealEstate()
        {
            return realEstateService.GetRealEstate();
        }

        [HttpPut("{id}")]
        public General<RealEstateViewModel> Update(int id, [FromBody] RealEstateViewModel user)
        {
            return realEstateService.Update(id, user);
        }

        [HttpDelete]
        public General<RealEstateViewModel> Delete(int id)
        {
            return realEstateService.Delete(id);
        }

        public List<RealEstate.DB.Entities.RealEstate> GetEstate()
        {
            return realEstateService.GetEstate();
        }
    }
}

