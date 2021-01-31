using AutoMapper;
using HospitalProductCatalog.Interfaces;
using HospitalProductCatalog.Models;
using HospitalProductCatalog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HospitalProductCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProductService productService;

        /// <summary>
        /// Initializes a new instance of the ProductController class.
        /// </summary>
        /// <param name="productService"></param>
        /// <param name="mapper"></param>
        public ProductController(IProductService productService, IMapper mapper)
        {
            this.mapper = mapper;
            this.productService = productService;
        }

        /// <summary>
        /// Lists all products.
        /// </summary>
        /// <returns>List of products with category and list of barcodes.</returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(ProductResource), 200)]
        public IEnumerable<ProductResource> GetProducts()
        {
            var products = productService.GetProducts();
            var resources = mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        /// <summary>
        /// Gets product by Id
        /// </summary>
        /// <param name="id">Id value of a product</param>
        /// <returns>Product</returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(ProductResource), 200)]
        public ProductResource GetProductById(int id)
        {
            var product = productService.GetProductById(id);
            var resource = mapper.Map<Product, ProductResource>(product);
            return resource;
        }

        /// <summary>
        /// Deletes an existing product
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Deleted product</returns>
        [HttpDelete]
        [Route("[action]")]
        [ProducesResponseType(typeof(ProductResource), 200)]
        public ProductResource DeleteProduct(int id)
        {
            var result = productService.DeleteProduct(id);
            var productResource = mapper.Map<Product, ProductResource>(result);
            return productResource;
        }

        /// <summary>
        /// Adds a new product to the list
        /// </summary>
        /// <param name="resource"></param>
        /// <returns>Newly added product</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProductResource), 200)]
        public ProductResource AddProduct([FromBody] SaveProductResource resource)
        {
            var product = mapper.Map<SaveProductResource, Product>(resource);
            var result = productService.AddProduct(product);
            var productResource = mapper.Map<Product, ProductResource>(result);
            return productResource;
        }

        /// <summary>
        /// Updates an existing product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns>Updated product</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductResource), 200)]
        public ProductResource EditProduct(int id, [FromBody] SaveProductResource resource)
        {
            var product = mapper.Map<SaveProductResource, Product>(resource);
            product.Id = id;
            var result = productService.EditProduct(product);
            var productResource = mapper.Map<Product, ProductResource>(result);
            return productResource;
        }
    }
}
