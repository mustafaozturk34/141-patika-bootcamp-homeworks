using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReaLEstate.Extension
{
    
    public static class Extension
    {
        // remove non alphanumeric characters
        public static string RemoveNonAlphanumeric(string text)
        {
            var result = Regex.Replace(text, @"[^A-Za-z0-9]+", " ");
            return result;

        }

        //get enum variable
        public static string GetEnum(this Enum _variable)
        {
            var result = _variable.GetType().GetMember(_variable.ToString()).First().GetCustomAttributes<DisplayAttribute>().First().Name;
            return result;
        }
    }
}
