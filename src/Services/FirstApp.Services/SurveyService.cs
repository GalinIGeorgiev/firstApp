using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

 
        public ManageSurveysViewModel ManageSurveys(ManageSurveysViewModel model)
        {
            List<Survey> Surveys = db.Surveys.Skip(Math.Max(0, db.Surveys.Count() - GlobalConstants.NUMBER_OF_SURVEYS_MANAGED)).ToList();

            for (int i = 0; i < Surveys.Count(); i++)
            {
                //TODO survey mapper
                if (model.surveyQuestions.Any(x => x.surveyQuestion == Surveys[i].surveyQuestion))
                {
                    continue;
                }

                model.surveyQuestions.Add(
                        new SurveyDTO()
                        {                           
                            surveyQuestion = Surveys[i].surveyQuestion,
                            isActive = Surveys[i].isActive
                        }
                    );
                            
            }

            model.surveyQuestions = model.surveyQuestions.ToList();

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

            if (viewModel.surveyQuestion != null)
            {
                activeSurveysViewModel.Add(viewModel);
            }
            

            return activeSurveysViewModel;
        }

        public void SetActiveSurveys(ManageSurveysViewModel model)
        {
            for (int i = 0; i < model.surveyQuestions.Count; i++)
            {
               List<Survey> surveys= db.Surveys.Where(x => x.surveyQuestion == model.surveyQuestions[i].surveyQuestion).ToList();

                foreach (var survey in surveys)
                {
                    survey.isActive = model.surveyQuestions[i].isActive;
                }
            }

            db.SaveChanges();
        }
    }
}
