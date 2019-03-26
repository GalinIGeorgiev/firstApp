using System.Collections.Generic;
using FirstApp.Data.Models;
using FirstApp.Services.ViewModels.Team;

namespace FirstApp.Services.Contracts
{
    public interface ITeamService
    {
        void CreateTeam(CreateTeamViewModel model);

        IEnumerable<Team> GetAllTeams();
    }
}