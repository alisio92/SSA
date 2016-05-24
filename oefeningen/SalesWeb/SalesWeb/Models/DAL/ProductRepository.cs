using SalesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data.Entity;

namespace SalesWeb.Models.DAL
{
    public class ProductRepository
    {

        public static List<Product> GetProducts()
        {
            using (SalesDBEntities context = new SalesDBEntities()) 
            {
                var query = (from p in context.Products select p);
                List<Product> allProducts = query.ToList<Product>();
                return allProducts;
            }
        }


        public static Product FindById(int? productID)
        {
            using (SalesDBEntities context = new SalesDBEntities())
            { 
                var query = (from p in context.Products where p.ProductID == productID select p);
                return query.SingleOrDefault<Product>();
            }
        }


        public static List<Product> FindByName(string productSearch)
        {
            using (SalesDBEntities context = new SalesDBEntities())
            {
                var query = (from p in context.Products.Include(p => p.Inventories)
                             where p.Name.Contains(productSearch) 
                             orderby p.Name descending
                             select p);

                //var query = (from p in context.Products select p);

                return query.ToList<Product>();
            }
        }
    }
}