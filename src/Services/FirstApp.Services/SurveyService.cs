using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FirstApp.Data;
using FirstApp.Data.Common;
using FirstApp.Data.Models;
using FirstApp.Services.Contracts;
using FirstApp.Services.Mapping;
using FirstApp.Services.ViewModels.Articles;
using FirstApp.Services.ViewModels.Home;
using FirstApp.Services.ViewModels.Survey;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace FirstApp.Services
{
    public class SurveyService : ISurveyService
    {

        private readonly FirstAppContext db;

        public SurveyService(FirstAppContext db)
        {
            this.db = db;
        }


        public void Create(CreateSurveyViewModel model)
        {         
            List<Survey> surveys =new List<Survey>();
            
            for (int i = 0; i < model.options.Count; i++)
            {
                Survey survey = new Survey()
                {
                    surveyQuestion = model.surveyQuestion,
                    option = model.options[i].surveyOption
                };
                

                surveys.Add(survey);
            }

            this.db.Surveys.AddRange(surveys);
            
            this.db.SaveChanges();        
        }

        public DetailsArticleViewModel DetailsArticle(int Id)
        {
            var article = db.Articles.Where(x => x.Id == Id).Include(x => x.Team).Include(x => x.Category)
                .Include(x => x.Images).Include(x => x.Videos).Include(x=>x.Comments).ThenInclude(x=>x.FirstAppUser).FirstOrDefault();

            var model = Mapper.Map<DetailsArticleViewModel>(article);

            // TODO no articles without img
            if (model.ImageUrl == null)
            {
                model.ImageUrl= "\\Images\\defaultPic.png";
            }
            return model;
        }

        public ManageSurveysViewModel ManageSurveys(ManageSurveysViewModel model)
        {
            List<Survey> Surveys = db.Surveys.Skip(Math.Max(0, db.Surveys.Count() - GlobalConstants.NUMBER_OF_SURVEYS_MANAGED)).ToList();


            for (int i = 0; i < Surveys.Count(); i++)
            {
                model.surveyQuestions.Add(Surveys[i].surveyQuestion);
            }

            model.surveyQuestions = model.surveyQuestions.Distinct().ToList();

            return model;
        }

        public ICollection<ActiveSurveysViewModel> GiveActiveSurveys()
        {
            //TODO
            var surveys = db.Surveys.Where(x=>x.isActive==true);
            var activeSurveysViewModel = new List<ActiveSurveysViewModel>();
            var surveyQuestionChecker = string.Empty;
            ActiveSurveysViewModel viewModel = new ActiveSurveysViewModel();

            foreach (var survey in surveys)
            {
                if (surveyQuestionChecker == survey.surveyQuestion)
                {
                    
                    viewModel.OptionsDictionary[survey.option] = survey.countVotes;
                }
                else
                {
                    surveyQuestionChecker = survey.surveyQuestion;

                    if (viewModel.surveyQuestion != null)
                    {
                        activeSurveysViewModel.Add(viewModel);
                    }
                    

                    viewModel = new ActiveSurveysViewModel()
                    {
                        surveyQuestion = survey.surveyQuestion,
                        OptionsDictionary = new Dictionary<string, int>()
                    };

                    viewModel.OptionsDictionary[survey.option] = survey.countVotes;

                    continue;
                }
            }
            activeSurveysViewModel.Add(viewModel);

            return activeSurveysViewModel;
        }

    }
}
