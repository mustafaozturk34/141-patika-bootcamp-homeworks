using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    //Kullanıcı Enum'ı
    public enum UserType
    {
        [Display(Name = "Administrator", GroupName = "Manager")]
        UserType1 = 1,
        
        [Display(Name = "Worker", GroupName = "Employee")]
        UserType2 = 2,

        [Display(Name = "Sellers" ,GroupName = "Consumer")]
        UserType3 = 3,

        [Display(Name = "Customer", GroupName = "Consumer")]
        UserType4 = 4,

    }
}
