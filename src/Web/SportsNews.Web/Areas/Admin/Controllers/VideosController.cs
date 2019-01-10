namespace SportsNews.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Controllers;
    using SportsNews.Services.DataServices;
    using SportsNews.Web.Areas.Admin.Models.Videos;
    using System.Threading.Tasks;

    public class VideosController : BaseController
    {
        private readonly IVideosService videosService;

        public VideosController(IVideosService videosService)
        {
            this.videosService = videosService;
        }

        public IActionResult Create(int id)
        {
            if (this.User.IsInRole("Administrator"))
            {
                return this.View();
            }

            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id, CreateVideoInputModel model)
        {
            if (this.User.IsInRole("Administrator"))
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(model);
                }
                await this.videosService.Create(id, model.VideoUrl);
            }
            return this.RedirectToAction("AllByArticleId", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int videoId)
        {
            if (this.User.IsInRole("Administrator"))
            {
                await this.videosService.Delete(videoId);
            }
            return this.RedirectToAction("AllByArticleId", new { id = id });
        }
    }
}
