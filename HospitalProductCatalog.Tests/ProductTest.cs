using AutoMapper;
using HospitalProductCatalog.Controllers;
using HospitalProductCatalog.Interfaces;
using HospitalProductCatalog.Mapper;
using HospitalProductCatalog.Models;
using HospitalProductCatalog.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace HospitalProductCatalog.Tests
{
    [TestClass]
    public class ProductTest
    {
        public IMapper Mapper { get; }
        private readonly ProductController _sut;
        private readonly Mock<IProductService> _mockService = new Mock<IProductService>();

        public ProductTest()
        {
            Mapper = new MapperConfiguration(c => c.AddProfile<Mapping>()).CreateMapper();

            _sut = new ProductController(_mockService.Object, Mapper);
        }

        /// <summary>
        /// Test category data
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProductData()
        {
            var output = new List<Product>()
            {
                new Product(){Id=100,Description="Implants"},
                new Product(){Id=101,Description="Consumables"}
            };
            return output;
        }

        /// <summary>
        /// Testcase for get all categories
        /// </summary>
        [TestMethod]
        public void Test_GetProducts()
        {
            _mockService.Setup(x => x.GetProducts()).Returns(GetProductData());
            var expected = GetProductData();
            var actual = _sut.GetProducts();
            Assert.IsTrue(expected.Count() == actual.Count());
        }

        /// <summary>
        /// Testcase to test add product
        /// </summary>
        [TestMethod]
        public void Test_AddProduct()
        {
            var saveproduct = new SaveProductResource
            {
                Description = "testAdd"
            };
            var product = Mapper.Map<Product>(saveproduct);
            product.Id = GetProductData().ToList().Max(i => i.Id)+1;
            _mockService.Setup(x => x.AddProduct(product)).Returns(product);

            var actual = _sut.AddProduct(saveproduct);

            Assert.IsNull(actual);
        }

        /// <summary>
        ///  Testcase to test update product
        /// </summary>
        [TestMethod]
        public void Test_UpdateProduct()
        {
            var saveproduct = new SaveProductResource
            {
                Description = "testUpdate"
            };
            var product = Mapper.Map<SaveProductResource, Product>(saveproduct);
            product.Id = 101;
            _mockService.Setup(x => x.EditProduct(product)).Returns(product);

            var actual = _sut.EditProduct(product.Id, saveproduct);

            Assert.IsNull(actual);
        }
    }
}
