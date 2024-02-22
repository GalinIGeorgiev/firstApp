using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Data.Models;
using FirstApp.Services.Mapping;

namespace FirstApp.Services.ViewModels.Survey

{
    public class CreateSurveyViewModel
    {
        [Display(Name = "Въпрос")]
        [Required(ErrorMessage = "Полето \"{0}\" e задължително.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Полето \"{0}\" трябва да бъде текст с минимална дължина {2} и максимална дължина {1}.")]
        public string surveyQuestion { get; set; }


        [Required(ErrorMessage = "Полето \"{0}\" e задължително.")]
        [Display(Name = "Брой опции")]
        [Range(2, 20)]
        public int numberOfOptions { get; set; }
      

        public List<AddOptionViewModel> options { get; set; }

    }
}
