using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Data.Models;
using FirstApp.Services.Mapping;

namespace FirstApp.Services.ViewModels.Survey

{
    public class AddOptionViewModel
    {
        [Display(Name = "Отговор")]
        [Required(ErrorMessage = "Полето \"{0}\" e задължително.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Полето \"{0}\" трябва да бъде текст с минимална дължина {2} и максимална дължина {1}.")]
        public string surveyOption { get; set; }    

        

    }
}
