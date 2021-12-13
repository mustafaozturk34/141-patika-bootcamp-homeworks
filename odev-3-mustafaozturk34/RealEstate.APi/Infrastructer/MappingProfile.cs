using AutoMapper;
using RealEstate.DB.Entities;
using RealEstate.Model;

namespace RealEstate.APi.Infrastructer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RealEstateOwnerViewModel, RealEstateOwner>();
            CreateMap<RealEstateOwner, RealEstateOwnerViewModel>();

            CreateMap<RealEstateViewModel, RealEstate.DB.Entities.RealEstate>();
            CreateMap<RealEstate.DB.Entities.RealEstate, RealEstateViewModel>();
        }

    }
}
