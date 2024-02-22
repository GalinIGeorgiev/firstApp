using FirstApp.Services.Mapping;
using System.Collections.Generic;
using AutoMapper;
using FirstApp.Data.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FirstApp.Services.ViewModels.Survey
{
    public class ManageSurveysViewModel 
    {
        public ManageSurveysViewModel()
        {
             this.surveyQuestions = new List<SurveyDTO>();
        }

        public  IList<SurveyDTO> surveyQuestions { get; set; } 
        
    }
}
