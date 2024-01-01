using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Data.Models;
using FirstApp.Services.Mapping;

namespace FirstApp.Services.ViewModels.Team

{
    public class CreateTeamViewModel 
    {
        [Display(Name = "Име на отбор")]
        [Required(ErrorMessage = "Полето \"{0}\" e задължително.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Полето \"{0}\" трябва да бъде текст с минимална дължина {2} и максимална дължина {1}.")]
        public string Name { get; set; } 
    }
}
