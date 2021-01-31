using HospitalProductCatalog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProductCatalog.Interfaces.Implementation
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the ProductService with ProductDbContext.
        /// </summary>
        /// <param name="dbContext"></param>
        public ProductService(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets list of products with category and barcodes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            return dbContext.Products
                .Include(p => p.Category)
                .Include(b => b.Barcodes)
                .ToList();
        }
        
        /// <summary>
        /// Gets product by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(int id)
        {
            return dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Barcodes)
                .FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Adds new product to the list
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Product AddProduct(Product product)
        {
            if (product != null)
            {
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
                return product;
            }
            return null;
        }

        /// <summary>
        /// Deletes an existing product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product DeleteProduct(int id)
        {
            var product = GetProductById(id);
            dbContext.Entry(product).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return product;
        }

        /// <summary>
        /// Updates an existing product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Product EditProduct(Product product)
        {
            dbContext.Entry(product).State = EntityState.Modified;
            dbContext.SaveChanges();
            return GetProductById(product.Id); ;
        }
    }
}
