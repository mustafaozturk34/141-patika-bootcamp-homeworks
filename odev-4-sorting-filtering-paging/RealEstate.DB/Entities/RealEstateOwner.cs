using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstate.DB.Entities
{
    public partial class RealEstateOwner
    {
        public RealEstateOwner()
        {
            RealEstate = new HashSet<RealEstate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Fortune { get; set; }
        public decimal RemainingSalary { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<RealEstate> RealEstate { get; set; }
    }
}
