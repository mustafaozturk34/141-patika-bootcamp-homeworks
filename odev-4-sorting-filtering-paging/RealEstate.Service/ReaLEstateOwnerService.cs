using AutoMapper;
using RealEstate.DB.Entities.DataContext;
using RealEstate.Model;
using RealEstate.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groot.Service.User
{

    
    public class RealEstateOwnerService : IRealEstateOwnerService
    {
        private readonly IMapper mapper;

        public RealEstateOwnerService(IMapper _mapper)
        {
            mapper = _mapper;
        }

        //login method for real estate owner
        public General<RealEstateOwnerViewModel> Login(LoginModel loginUser)
        {
            General<RealEstateOwnerViewModel> result = new();

            using (var context = new RealEstateContext())
            {
                var data = context.RealEstateOwner.FirstOrDefault(x => 
                                                x.Email == loginUser.Email &&
                                                x.Password == loginUser.Password);
                if (data is not null)
                {
                    result.Entity = mapper.Map<RealEstateOwnerViewModel>(data);
                }
            }

            return result;
        }


        //create method for real estate owner
        public General<RealEstateOwnerViewModel> Insert(RealEstateOwnerViewModel newUser)
        {
            var result = new General<RealEstateOwnerViewModel> ();
            try
            {
                var model = mapper.Map<RealEstate.DB.Entities.RealEstateOwner>(newUser);
                using (var srv = new RealEstateContext())
                {
                    srv.RealEstateOwner.Add(model);
                    srv.SaveChanges();
                    result.Entity = mapper.Map<RealEstateOwnerViewModel>(model);
                }
            }
            catch (Exception)
            {

                result.ExceptionMessage = "Beklenmeyen bir sorun oluştu.";
            }

            return result;
        }



        //all list method for real estate owner
        public General<RealEstateOwnerViewModel> GetUsers()
        {
            var result = new General<RealEstateOwnerViewModel>();

            using (var context = new RealEstateContext())
            {
                var data = context.RealEstateOwner.OrderBy(x => x.Id);

                if (data.Any())
                {
                    result.List = mapper.Map<List<RealEstateOwnerViewModel>>(data);

                }
                else
                {
                    result.ExceptionMessage = "Hiçbir kullanıcı bulunamadı.";
                }
            }

            return result;
        }

        //update method for real estate owner
        public General<RealEstateOwnerViewModel> Update(int id, RealEstateOwnerViewModel user)
        {
            var result = new General<RealEstateOwnerViewModel>();

            using (var context = new RealEstateContext())
            {
                var updateUser = context.RealEstateOwner.SingleOrDefault(i => i.Id == id);

                if (updateUser is not null)
                {
                    updateUser.Name = user.Name;
                    updateUser.Fortune = user.Fortune;
                    updateUser.Email = user.Email;
                    updateUser.Password = user.Password;

                    context.SaveChanges();

                    result.Entity = mapper.Map<RealEstateOwnerViewModel>(updateUser);

                }
                else
                {
                    result.ExceptionMessage = "Kullanıcı bulunamadı.";
                }
            }

            return result;
        }

        //delete method for real estate owner
        public General<RealEstateOwnerViewModel> Delete(int id)
        {
            var result = new General<RealEstateOwnerViewModel>();

            using (var context = new RealEstateContext())
            {
                var user = context.RealEstateOwner.SingleOrDefault(i => i.Id == id);

                if (user is not null)
                {
                    context.RealEstateOwner.Remove(user);
                    context.SaveChanges();

                    result.Entity = mapper.Map<RealEstateOwnerViewModel>(user);
                }
                else
                {
                    result.ExceptionMessage = "Kullanıcı bulunamadı.";
                }
            }

            return result;
        }

        //remaining salary adjusted
        public void Remaning(RealEstateViewModel newReal)
        {
            var result = new RealEstateOwnerViewModel();

            using (var context = new RealEstateContext())
            {
                var updateUser = context.RealEstateOwner.SingleOrDefault(i => i.Id == newReal.Iuser);

                updateUser.RemainingSalary = (updateUser.Fortune - newReal.Price);

                context.SaveChanges();


            }
        }


    }
}
