﻿using FirstApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Services.ViewModels.Home
{
    public class ArticleViewModel
    {
        public string Content { get; set; }
        public string Category { get; set; }
        public string CreatedOn { get; set; }
        public string ImageUrl { get; set; }

    }
}