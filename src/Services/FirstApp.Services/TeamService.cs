using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using FirstApp.Data;
using FirstApp.Data.Models;
using FirstApp.Services.Contracts;
using FirstApp.Services.ViewModels.Category;
using FirstApp.Services.ViewModels.Team;

namespace FirstApp.Services
{
    public class TeamService : ITeamService
    {
        private FirstAppContext Db;

        public TeamService(FirstAppContext db)
        {
            this.Db = db;
        }

        
        public void CreateTeam(CreateTeamViewModel model)
        {
            var team = new Team()
            {
                Name = model.Name
            };
            this.Db.Teams.Add(team);
            this.Db.SaveChanges();
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return Db.Teams.OrderBy(x => x.Name).ToList();
        }
    }
}
