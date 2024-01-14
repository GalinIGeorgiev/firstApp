using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Data.Common;

namespace FirstApp.Data.Models
{
    public class Survey : BaseModel<int>
    {
        public string surveyQuestion { get; set; }

        public string option { get; set; }

        public bool isActive { get; set; } =  false;

        public int countVotes { get; set; }

        public void increaseCountVotes()
        {
            countVotes++;
        }
    }
}
