using FirstApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Services.ViewModels.Category;
using FirstApp.Services.ViewModels.Home;

namespace FirstApp.Services.Contracts
{
    public interface ICategoryService
    {
        void CreateCategory(CreateCategoryViewModel model);
        IEnumerable<Category> GetAllCategories();

        
    }
}
