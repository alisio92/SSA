using nmct.ba.demo.database.da;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.demo.database.ui
{
    class Program
    {
        static void Main(string[] args)
        {
            Organisation o = new Organisation()
            {
                Login = "administrator",
                Password = "admin",
                DbName = "KVKortrijk",
                DbLogin = "KVKortrijk",
                DbPassword = "kvk",
                OrganisationName = "Kv Kortrijk bvba",
                Address = "Moorselestraat 18",
                Email = "info@kvk.be",
                Phone = "056/12.34.56"
            };

            Organisation.InsertOrganisation(o);

            Console.WriteLine("Created Organisation");
            Console.ReadLine();
        }
    }
}
