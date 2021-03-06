﻿using SportsNews.Data.Common;

namespace SportsNews.Data.Models
{
    using System.Collections.Generic;

    public class Article : BaseModel<int>
    {
        public Article()
        {
            this.Comments = new List<Comment>();
            this.Images = new List<Image>();
            this.Videos = new List<Video>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<Video> Videos { get; set; }
    }
}
