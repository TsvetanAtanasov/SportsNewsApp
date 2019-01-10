using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsNews.Web.Controllers
{
    using Areas.Identity.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Comments;
    using Services.Controllers;
    using Services.DataServices;
    using Services.Models.Articles;

    public class CommentsController : BaseController
    {
        private readonly ICommentsService commentsService;
        private readonly UserManager<SportsNewsUser> userManager;

        public CommentsController(ICommentsService commentsService, UserManager<SportsNewsUser> userManager)
        {
            this.commentsService = commentsService;
            this.userManager = userManager;
        }
        
        [Authorize]
        public IActionResult Create(int id)
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(int id, CreateCommentInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            await this.commentsService.Create(id, user.Id, model.Content);
            return this.RedirectToAction("Details", "Articles", new {id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int commentId)
        {
            if (this.User.IsInRole("Administrator"))
            {
                await this.commentsService.Delete(commentId);
            }
            return this.RedirectToAction("Details", "Articles", new { id = id });
        }
    }
}
