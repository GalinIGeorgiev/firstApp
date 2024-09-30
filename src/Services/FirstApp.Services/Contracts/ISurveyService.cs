using FirstApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Services.ViewModels.Articles;
using FirstApp.Services.ViewModels.Home;
using FirstApp.Services.ViewModels.Survey;

namespace FirstApp.Services.Contracts
{
    public interface ISurveyService
    {        
        void Create(CreateSurveyViewModel model);

        ICollection<ActiveSurveysViewModel> GiveActiveSurveys();

        ManageSurveysViewModel ManageSurveys(ManageSurveysViewModel model);
        void SetActiveSurveys(ManageSurveysViewModel model);
        void AddVote(int id);



    }
}
