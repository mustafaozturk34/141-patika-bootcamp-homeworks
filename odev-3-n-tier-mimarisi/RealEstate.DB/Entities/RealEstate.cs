using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstate.DB.Entities
{
    public partial class RealEstate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Type { get; set; }
        public decimal SquareMeters { get; set; }
        public int Iuser { get; set; }

        public virtual RealEstateOwner IuserNavigation { get; set; }
    }
}
