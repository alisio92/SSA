using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBasis.Models.DAL
{
    public class DomainListRepository
    {
        public List<Domain> Domains {get;set;}

        private static List<Domain> _lstDomains = new List<Domain>
        {
            new Domain {Id=1,Code="WD-list",Name="Web & Design", Description="Attractieve, responsieve GUI's",Year=new DateTime(2013,9,15)},
            new Domain {Id=2,Code="AD-list",Name="Application development", Description="Object oriented programming",Year=new DateTime(2013,9,15)},
            new Domain {Id=3,Code="DES-list",Name="Digital Expert Skills", Description="Een proffesionele houding",Year=new DateTime(2013,9,15)},
            new Domain {Id=4,Code="SSD-list",Name="Server Side Development", Description="Attractieve, responsieve GUI's",Year=new DateTime(2013,9,15)},
            new Domain {Id=5,Code="IFS-list",Name="Infrastructure", Description="Attractieve, responsieve GUI's",Year=new DateTime(2013,9,15)}
        };

        public DomainListRepository()
        {
            Domains = _lstDomains;
        }

        public Domain FindById(int id)
        {
            if (id <= 0 || id >= 6)
                return null;

            var domain = Domains.Find(item => item.Id == id);
            return domain;
        }

        public void Update(Domain domain)
        {
            //var _domain = Domains.Find(item => item.Id == domain.Id);
            //_domain = domain;

            Domains[domain.Id-1] = domain;
        }

        public void Insert(Domain domain)
        {

            Domains.Add(domain);
        }
    }
}