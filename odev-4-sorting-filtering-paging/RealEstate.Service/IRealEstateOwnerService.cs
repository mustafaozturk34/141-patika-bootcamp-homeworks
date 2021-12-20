using RealEstate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Service
{
    //interface created
    public interface IRealEstateOwnerService
    {
        public General<RealEstateOwnerViewModel> Login(LoginModel loginUser);
        public General<RealEstateOwnerViewModel> Insert(RealEstateOwnerViewModel newUser);
        public General<RealEstateOwnerViewModel> GetUsers();
        public General<RealEstateOwnerViewModel> Update(int id, RealEstateOwnerViewModel user);
        public General<RealEstateOwnerViewModel> Delete(int id);
        public void Remaning(RealEstateViewModel newReal);
    }
}
