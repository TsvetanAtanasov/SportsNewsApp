namespace SportsNews.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Controllers;
    using Services.DataServices;
    using SportsNews.Services.Models.Videos;
    using System.Threading.Tasks;

    public class VideosController : BaseController
    {
        private readonly IVideosService videosService;

        public VideosController(IVideosService videosService)
        {
            this.videosService = videosService;
        }

        [Authorize]
        public IActionResult AllByArticleId(int id)
        {
            var videos = this.videosService.GetAllByArticleId(id);
            var viewModel = new AllVideosViewModel
            {
                Videos = videos
            };
            return this.View(viewModel);
        }
    }
}
