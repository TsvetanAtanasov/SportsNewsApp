using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsNews.Services.DataServices
{
    using Data.Common;
    using Data.Models;

    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> commentRepository;

        public CommentsService(IRepository<Comment> commentRepository)
        {
            this.commentRepository = commentRepository;
        }
        public async Task Create(int articleId, string userId, string content)
        {
            var comment = new Comment()
            {
                ArticleId = articleId,
                UserId = userId,
                Content = content
            };

            await this.commentRepository.AddAsync(comment);
            await this.commentRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var comment = this.commentRepository.All().FirstOrDefault(x => x.Id == id);
            this.commentRepository.Delete(comment);
            await this.commentRepository.SaveChangesAsync();
        }
    }
}
