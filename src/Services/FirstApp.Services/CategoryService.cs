using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using AutoMapper;
using FirstApp.Data;
using FirstApp.Data.Models;
using FirstApp.Services.Contracts;
using FirstApp.Services.ViewModels.Category;

namespace FirstApp.Services
{
    public class CategoryService : ICategoryService
    {
        private FirstAppContext Db;

        public CategoryService(FirstAppContext db)
        {
            this.Db = db;
        }



        public void CreateCategory(CreateCategoryViewModel model)
        {
            // TODO
            var c = Mapper.Map<Category>(model);


            var category = new Category()
            {
                Name = model.Name
            };
            this.Db.Categories.Add(category);
            this.Db.SaveChanges();
        }



        public IEnumerable<Category> GetAllCategories()
        {
            return this.Db.Categories.OrderBy(x => x.Name).ToList();
        }
    }
}
