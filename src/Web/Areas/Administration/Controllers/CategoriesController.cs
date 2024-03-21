using FirstApp.Services.Contracts;
using FirstApp.Services.ViewModels.Category;
using FirstApp.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FirstApp.Web.Areas.Administration.Controllers
{
    public class CategoriesController : AdministrationBaseController
    {
        private readonly ICategoryService categoriesService;

        public CategoriesController(ICategoryService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            categoriesService.CreateCategory(model);

            return RedirectToAction("Index","Home");
        }
    }
}