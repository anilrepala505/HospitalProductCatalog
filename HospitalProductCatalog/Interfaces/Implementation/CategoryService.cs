using HospitalProductCatalog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProductCatalog.Interfaces.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ProductDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the CategoryService with ProductDbContext.
        /// </summary>
        /// <param name="dbContext"></param>
        public CategoryService(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets categories list
        /// </summary>
        /// <returns>List of categories</returns>
        public IEnumerable<Category> GetCategories()
        {
            return dbContext.Categories.ToList();
        }

        /// <summary>
        /// Adds a new category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public Category AddCategory(Category category)
        {

            if (category != null)
            {
                dbContext.Categories.Add(category);
                dbContext.SaveChanges();
                return category;
            }
            return null;
        }

        /// <summary>
        /// Updates an existing category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoryname"></param>
        /// <returns></returns>
        public Category EditCategory(int id, string categoryname)
        {
            var category = GetCategoryById(id);
            category.Name = categoryname;
            dbContext.Entry(category).State = EntityState.Modified;
            dbContext.SaveChanges();
            return category;
        }

        /// <summary>
        /// Gets category by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetCategoryById(int id)
        {
            return dbContext.Categories.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Deletes an existing category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category DeleteCategory(int id)
        {
            var category = GetCategoryById(Convert.ToInt32(id));
            dbContext.Entry(category).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return category;
        }
    }
}
