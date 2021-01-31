using Autofac.Extras.Moq;
using AutoMapper;
using HospitalProductCatalog.Controllers;
using HospitalProductCatalog.Interfaces;
using HospitalProductCatalog.Interfaces.Implementation;
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
    public class CategoryTests
    {
        public IMapper Mapper { get; }
        private readonly CategoryController _sut;
        private readonly Mock<ICategoryService> _mockService = new Mock<ICategoryService>();
        public CategoryTests()
        {
            Mapper = new MapperConfiguration(c => c.AddProfile<Mapping>()).CreateMapper();

            _sut = new CategoryController(_mockService.Object, Mapper);
        }
        /// <summary>
        /// Test category data
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCatagoryData()
        {
            var output = new List<Category>()
            {
                new Category(){Id=100,Name="Implants"},
                new Category(){Id=101,Name="Consumables"}
            };
            return output;
        }

        /// <summary>
        /// Testcase for get all categories
        /// </summary>
        [TestMethod]
        public void Test_GetCatagories()
        {
            _mockService.Setup(x => x.GetCategories()).Returns(GetCatagoryData());
            var expected = GetCatagoryData();
            var actual = _sut.GetCategories();
            Assert.IsTrue(expected.Count() == actual.Count());
        }


        /// <summary>
        /// Testcase to test add category
        /// </summary>
        [TestMethod]
        public void Test_AddCategory()
        {
            var category = new Category
            {
                Id = 103,
                Name = "save"
            };

            _mockService.Setup(x => x.AddCategory(category)).Returns(category);

            var actual = _sut.AddCategory(category.Name);

            Assert.IsNull(actual);
        }

        /// <summary>
        /// Testcase to test update category
        /// </summary>
        [TestMethod]
        public void Test_UpdateCategory()
        {
            var category = new Category
            {
                Id = 101,
                Name = "save"
            };

            _mockService.Setup(x => x.EditCategory(category.Id,category.Name)).Returns(category);

            var actual = _sut.EditCategory(category.Id, category.Name);

            Assert.IsTrue(actual.Name==category.Name);
        }
    }
}
