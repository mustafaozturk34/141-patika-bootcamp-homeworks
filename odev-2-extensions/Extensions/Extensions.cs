using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Extensions
{
    public static class Extensions
    {
        //Girilen metindeki harf, sayı ve boşluk harici bütün karakterleri silen fonksiyon
        public static string RemoveNonAlphanumeric(string text)
        {
            var result = Regex.Replace(text, @"[^A-Za-z0-9]+", " ");
            return result;

        }

        //Enum'ın Name ve GroupName'ini getirir.
        public static string GetEnumDisplay(this Enum _enum)
        {
            var Name = _enum.GetType().GetMember(_enum.ToString()).First().GetCustomAttributes<DisplayAttribute>().First().Name;
            var GroupName = _enum.GetType().GetMember(_enum.ToString()).First().GetCustomAttributes<DisplayAttribute>().First().GroupName;
            return Name + "-" + GroupName;
        }
    }
}
