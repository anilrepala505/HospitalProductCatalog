using HospitalProductCatalog.Models;
using System.Collections.Generic;

namespace HospitalProductCatalog.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();

        Category AddCategory(Category category);

        Category EditCategory(int id, string categoryname);

        Category DeleteCategory(int id);

        Category GetCategoryById(int id);
    }
}
