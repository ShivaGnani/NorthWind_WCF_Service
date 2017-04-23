using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataModels;

namespace NorthWind_WCF_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductsService.svc or ProductsService.svc.cs at the Solution Explorer and start debugging.
    public class ProductsService : IProductsService
    {
        NORTHWINDEntities db = null;
        public ICollection<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            db = new NORTHWINDEntities();
            var dbProducts = db.spGetAllProducts();
            foreach (var product in dbProducts)
            {
                products.Add(new Product
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    CategoryID = product.CategoryID,
                    QuantityPerUnit = product.QuantityPerUnit,
                    UnitPrice = product.UnitPrice,
                    UnitsInStock = product.UnitsInStock,
                    Discontinued = product.Discontinued
                });
            }
            return products;
        }
    }
}
