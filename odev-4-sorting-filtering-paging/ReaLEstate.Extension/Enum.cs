using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaLEstate.Extension
{
    // enum created
    public enum Enum
    {
        [Display (Name = "Arsa")]
        type1 = 1,
        [Display(Name = "Tarla")]
        type2 = 2,
    }
}
