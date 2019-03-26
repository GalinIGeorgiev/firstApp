using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Web.Controllers
{
    public class CommentsController : BaseController
    {

        public IActionResult AddCommentArticle()
        {
            return View();
        }
    }
}