using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Services.ViewModels.Survey
{
    public class ActiveSurveysViewModel
    {
        public string surveyQuestion { get; set; }

        public  IDictionary<string,int> OptionsDictionary { get; set; }
    }
}
