using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ArticlesController : AdministrationBaseController
    {

        public ArticlesController()
        {

        }


        public IActionResult Create()
        {
            return View();
        }


        //[HttpPost]
        //public IActionResult Create()
        //{
        //    return View();
        //}
    }
}
