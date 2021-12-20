using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RealEstate.APi.Infrastructer;
using RealEstate.Model;
using RealEstate.Service;
using System.Collections.Generic;

namespace RealEstate.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : BaseController
    {
        private readonly IRealEstateService realEstateService;
        private readonly IMemoryCache memoryCache;


        public RealEstateController(IRealEstateService _realEstateService, IMemoryCache _memoryCache) : base(_memoryCache)
        {
            realEstateService = _realEstateService;
            memoryCache = _memoryCache;
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

        [HttpGet("getestate")]
        public List<RealEstate.DB.Entities.RealEstate> GetEstate()
        {
            return realEstateService.GetEstate();
        }

        [HttpGet]
        [Route("sort")]
        public General<RealEstateViewModel> SortingRealEstate([FromQuery] string sortingType)
        {
            return realEstateService.SortingRealEstate(sortingType);
        }

        // Filtrelenmiş ürünlerin listeleneceği metodun servis katmanından çağırıldığı kısım
        [HttpGet]
        [Route("filter")]
        public General<RealEstateViewModel> FilterRealEstate([FromQuery] string filterByName)
        {
            return realEstateService.FilterRealEstate(filterByName);
        }

        [HttpGet]
        [Route("pagination")]
        public General<RealEstateViewModel> RealEstatePagination([FromQuery] int realEstateByPage, [FromQuery] int displayPageNo)
        {
            return realEstateService.RealEstatePagination(realEstateByPage, displayPageNo);
        }
    }
}

