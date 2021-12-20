using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Model
{

    //method by which general properties are defined
    public class General<T>
        {
            public T Entity { get; set; }
            public List<T> List { get; set; }
            public int TotalCount { get; set; }
            public decimal TotalPage { get; set; }
            public string ExceptionMessage { get; set; }

        }
}
