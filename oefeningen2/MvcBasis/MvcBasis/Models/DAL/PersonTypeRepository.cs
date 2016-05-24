using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBasis.Models.DAL
{
    public class PersonTypeRepository
    {
        public List<PersonType> PersonTypes;

        private static List<PersonType> _lstPersonTypes =
            new List<PersonType>
            {
                new PersonType{Name="Docent"},
                new PersonType{Name="Student"},
                new PersonType{Name="Alumni"}
            };

        public PersonTypeRepository()
        {
            PersonTypes = _lstPersonTypes;
        }
    }
}