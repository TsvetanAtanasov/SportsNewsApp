﻿using SportsNews.Data.Models;
using SportsNews.Services.Mapping;

namespace SportsNews.Services.Models.Home
{
    public class ArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string CategoryName { get; set; }
    }
}
