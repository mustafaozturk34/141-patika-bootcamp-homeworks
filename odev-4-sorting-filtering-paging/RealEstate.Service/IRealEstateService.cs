using RealEstate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Service
{
    //interface created
    public interface IRealEstateService
    {
        public General<RealEstateViewModel> Insert(RealEstateViewModel newRealEstate);
        public General<RealEstateViewModel> GetRealEstate();
        public General<RealEstateViewModel> Update(int id, RealEstateViewModel realEstate);
        public General<RealEstateViewModel> Delete(int id);
        public List<RealEstate.DB.Entities.RealEstate> GetEstate();
        public General<RealEstateViewModel> SortingRealEstate(string sortingType);
        public General<RealEstateViewModel> RealEstatePagination(decimal realEstateByPage, int displayPageNo);
        public General<RealEstateViewModel> FilterRealEstate(string filterByName);



    }
}
