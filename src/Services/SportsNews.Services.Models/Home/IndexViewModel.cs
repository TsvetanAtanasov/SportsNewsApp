namespace SportsNews.Services.Models.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<ArticleViewModel> Articles { get; set; }
    }
}
