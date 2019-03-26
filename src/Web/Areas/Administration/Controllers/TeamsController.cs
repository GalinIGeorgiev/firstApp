using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using FirstApp.Services.ViewModels.Articles;
using FirstApp.Services.ViewModels.Team;

namespace FirstApp.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TeamsController : AdministrationBaseController
    {
        private ITeamService TeamService;

        public TeamsController(ITeamService teamService)
        {
            TeamService = teamService;
        }

        

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTeamViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }
            TeamService.CreateTeam(model);
            return View();
        }


        //[HttpPost]
        //public async Task<IActionResult> Create(CreateArticleViewModel model)
        //{
        //    return View();
        //}
    }
}
