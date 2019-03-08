using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Data.Common;

namespace FirstApp.Data.Models
{
    public class Poll : BaseModel<int>
    {
        public IDictionary<string, int> Options { get; set; }


    }
}
