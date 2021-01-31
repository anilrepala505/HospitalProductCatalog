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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        /// <summary>
        ///  Initializes a new instance of the Categorycontroller class.
        /// </summary>
        /// <param name="categoryService"></param>
        /// <param name="mapper"></param>
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Lists all categories.
        /// </summary>
        /// <returns>List of categories.</returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(IEnumerable<CategoryResource>), 200)]
        public IEnumerable<CategoryResource> GetCategories()
        {
            var categories = categoryService.GetCategories();
            var resources = mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;
        }

        /// <summary>
        /// Gets a category by Id
        /// </summary>
        /// <param name="id">Id value of the category</param>
        /// <returns>Category</returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(CategoryResource), 200)]
        public CategoryResource GetCategoryById(int id)
        {
            var category = categoryService.GetCategoryById(id);
            var resource = mapper.Map<Category, CategoryResource>(category);
            return resource;
        }

        /// <summary>
        /// Saves new catagory
        /// </summary>
        /// <param name="category">category name</param>
        /// <returns>Created catagory</returns>
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(CategoryResource), 200)]
        public CategoryResource AddCategory(string category)
        {
            var newCategory = new Category() { Name = category };
            var result = categoryService.AddCategory(newCategory);
            var categoryResource = mapper.Map<Category, CategoryResource>(result);
            return categoryResource;
        }

        /// <summary>
        /// Updates existing category
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="newCateory">category details</param>
        /// <returns>Updated category</returns>
        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(typeof(CategoryResource), 200)]
        public CategoryResource EditCategory(int id, string newCateory)
        {
            var result = categoryService.EditCategory(id, newCateory);
            var categoryResource = mapper.Map<Category, CategoryResource>(result);
            return categoryResource;
        }

        /// <summary>
        /// Deletes an existing category
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deleted category</returns>
        [HttpDelete]
        [Route("[action]")]
        [ProducesResponseType(typeof(CategoryResource), 200)]
        public CategoryResource DeleteCategory(int id)
        {
            var result = categoryService.DeleteCategory(id);
            var categoryResource = mapper.Map<Category, CategoryResource>(result);
            return categoryResource;
        }
    }
}
