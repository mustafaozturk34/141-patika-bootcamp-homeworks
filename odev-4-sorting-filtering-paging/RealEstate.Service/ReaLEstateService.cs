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
                    updateRealEstate.Price = realEstate.Price;
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

        public General<RealEstateViewModel> SortingRealEstate(string sortingType)
        {
            var result = new General<RealEstateViewModel>();
            using (var context = new RealEstateContext())
            {
                var realEstate = context.RealEstate.Where(x => x.Id > 0);

                switch (sortingType)
                {
                    case "Name":
                        realEstate = realEstate.OrderBy(x => x.Name);
                        break;
                    case "DescName":
                        realEstate = realEstate.OrderByDescending(x => x.Name);
                        break;
                    case "Price":
                        realEstate = realEstate.OrderBy(x => x.Price);
                        break;
                    case "DescPrice":
                        realEstate = realEstate.OrderByDescending(x => x.Price);
                        break;
                    case "SquareMeters":
                        realEstate = realEstate.OrderBy(x => x.SquareMeters);
                        break;
                    case "DescSquareMeters":
                        realEstate = realEstate.OrderByDescending(x => x.SquareMeters);
                        break;
                    case "Type":
                        realEstate = realEstate.OrderBy(x => x.Type);
                        break;
                    case "DescType":
                        realEstate = realEstate.OrderByDescending(x => x.Type);
                        break;
                    default:
                        realEstate = realEstate.OrderBy(x => x.Id);
                        break;
                }

                result.List = mapper.Map<List<RealEstateViewModel>>(realEstate);
            }

            return result;
        }

        public General<RealEstateViewModel> RealEstatePagination(decimal realEstateByPage, int displayPageNo)
        {
            var result = new General<RealEstateViewModel>();
            decimal _totalCount = 0;
            decimal _totalPage = 0;

            using (var context = new RealEstateContext())
            {
                result.TotalCount = context.RealEstate.Count();
                _totalCount = result.TotalCount;
                _totalPage = Math.Ceiling(_totalCount / realEstateByPage);

                var _realEstate = context.RealEstate
                                        .OrderBy(i => i.Id)
                                        .Skip((int)((displayPageNo - 1) * realEstateByPage))
                                        .Take((int)realEstateByPage).ToList();

                result.List = mapper.Map<List<RealEstateViewModel>>(_realEstate);
            }

            result.TotalPage = _totalPage;

            return result;
        }

        public General<RealEstateViewModel> FilterRealEstate(string filterByName)
        {
            var result = new General<RealEstateViewModel>();
            using (var context = new RealEstateContext())
            {
                var realEstate = context.RealEstate.Where(x => x.Id > 0);

                if (filterByName != null || filterByName != "")
                {
                    realEstate = realEstate.Where(i => i.Name.StartsWith(filterByName));
                }
                else
                {
                    result.ExceptionMessage = "Please your search again";
                    return result;
                }

                result.List = mapper.Map<List<RealEstateViewModel>>(realEstate);
            }

            return result;
        }
    }
}
