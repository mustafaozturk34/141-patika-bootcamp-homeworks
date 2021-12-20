using AutoMapper;
using RealEstate.DB.Entities.DataContext;
using RealEstate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Service
{
    //real estate transactions
    public class RealEstateService : IRealEstateService
    {
        private readonly IMapper mapper;
        private readonly IRealEstateOwnerService realEstateOwnerService;

        public RealEstateService(IMapper _mapper, IRealEstateOwnerService _realEstateOwnerService)
        {
            mapper = _mapper;
            realEstateOwnerService = _realEstateOwnerService;
        }


        //create method for real estate
        public General<RealEstateViewModel> Insert(RealEstateViewModel newRealEstate)
        {
            var result = new General<RealEstateViewModel>();
            try
            {

                var model = mapper.Map<RealEstate.DB.Entities.RealEstate>(newRealEstate);
                using (var srv = new RealEstateContext())
                {
                    srv.RealEstate.Add(model);
                    srv.SaveChanges();
                    realEstateOwnerService.Remaning(newRealEstate);
                    result.Entity = mapper.Map<RealEstateViewModel>(model);
                }
            }
            catch (Exception)
            {

                result.ExceptionMessage = "Beklenmeyen bir sorun oluştu.";
            }

            return result;
        }

        //list method for real estate
        public List<RealEstate.DB.Entities.RealEstate> GetEstate()
        {
            using (var context = new RealEstateContext())
            {
                var data = context.RealEstate
                    .Where(x => x.Iuser == 1)
                    .OrderBy(x => x.Id).ToList();

                return data;
            }


        }

        //full list method for real estate
        public General<RealEstateViewModel> GetRealEstate()
        {
            var result = new General<RealEstateViewModel>();

            using (var context = new RealEstateContext())
            {
                var data = context.RealEstateOwner.OrderBy(x => x.Id);

                if (data.Any())
                {
                    result.List = mapper.Map<List<RealEstateViewModel>>(data);

                }
                else
                {
                    result.ExceptionMessage = "Hiçbir gayrimenkul bulunamadı.";
                }
            }

            return result;
        }

        //update method for real estate
        public General<RealEstateViewModel> Update(int id, RealEstateViewModel realEstate)
        {
            var result = new General<RealEstateViewModel>();

            using (var context = new RealEstateContext())
            {
                var updateRealEstate = context.RealEstate.SingleOrDefault(i => i.Id == id);

                if (updateRealEstate is not null)
                {
                    updateRealEstate.Price= realEstate.Price;
                    updateRealEstate.SquareMeters = realEstate.SquareMeters;
                    updateRealEstate.Type = realEstate.Type;

                    context.SaveChanges();
                    realEstateOwnerService.Remaning(realEstate);


                    result.Entity = mapper.Map<RealEstateViewModel>(updateRealEstate);

                }
                else
                {
                    result.ExceptionMessage = "gayrimenkul bulunamadı.";
                }
            }

            return result;
        }

        ////delete method for real estate
        public General<RealEstateViewModel> Delete(int id)
        {
            var result = new General<RealEstateViewModel>();

            using (var context = new RealEstateContext())
            {
                var realEstate = context.RealEstateOwner.SingleOrDefault(i => i.Id == id);

                if (realEstate is not null)
                {
                    context.RealEstateOwner.Remove(realEstate);
                    context.SaveChanges();


                    result.Entity = mapper.Map<RealEstateViewModel>(realEstate);
                }
                else
                {
                    result.ExceptionMessage = "gayrimenkul bulunamadı.";
                }
            }

            return result;
        }



    }
}
