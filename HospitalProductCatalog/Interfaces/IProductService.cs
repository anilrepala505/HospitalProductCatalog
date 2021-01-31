using HospitalProductCatalog.Models;
using System.Collections.Generic;

namespace HospitalProductCatalog.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();

        Product GetProductById(int id);

        Product DeleteProduct(int id);

        Product EditProduct(Product product);

        Product AddProduct(Product product);
    }
}
