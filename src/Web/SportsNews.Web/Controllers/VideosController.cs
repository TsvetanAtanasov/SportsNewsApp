namespace SportsNews.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Controllers;
    using Services.DataServices;
    using SportsNews.Web.Models.Videos;
    using System.Threading.Tasks;

    public class VideosController : BaseController
    {
        private readonly IVideosService videosService;

        public VideosController(IVideosService videosService)
        {
            this.videosService = videosService;
        }

        [Authorize]
        public IActionResult Create(int id)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id, CreateVideoInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.videosService.Create(id, model.VideoUrl);
            return this.RedirectToAction("Details", "Articles", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int videoId)
        {

            await this.videosService.Delete(videoId);
            return this.RedirectToAction("Details", "Articles", new { id = id });
        }
    }
}
