using Extensions;
using System;

namespace Homework2_Extensions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //String düzenlemek için extension 
            Extensions.Extensions.RemoveNonAlphanumeric("Gelecek Varlık */-.@ Bootcamp - 2021+");
            Console.WriteLine(Extensions.Extensions.RemoveNonAlphanumeric("Gelecek Varlik */-.@ Bootcamp - 2021"));

            //Kullanıcı tipi için extension
            Console.WriteLine(Extensions.Extensions.GetEnumDisplay(Extensions.UserType.UserType1));
            String[] Display = Extensions.Extensions.GetEnumDisplay(Extensions.UserType.UserType1).Split("-");
            Console.WriteLine(Display[1]);

            string[] userType = Extensions.Extensions.GetEnumDisplay(Extensions.UserType.UserType4).Split("-");
            Console.WriteLine(userType[1]);
        }
    }
}
