using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsNews.Web.Models.Comments
{
    public class CreateCommentInputModel
    {
        public int ArticleId { get; set; }

        public string Content { get; set; }
    }
}
