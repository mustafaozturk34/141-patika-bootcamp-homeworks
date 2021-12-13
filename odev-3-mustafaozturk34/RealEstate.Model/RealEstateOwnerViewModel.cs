using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Model
{
    // real estate owner view model layer
    public class RealEstateOwnerViewModel
    {
        public string Name { get; set; }
        public decimal Fortune { get; set; }
        public decimal? RemainingSalary { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
