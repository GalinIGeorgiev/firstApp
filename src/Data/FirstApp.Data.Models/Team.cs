using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Data.Common;

namespace FirstApp.Data.Models
{
    public class Team:BaseModel<int>
    {
        public string Name { get; set; }
    }
}
