namespace SportsNews.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Controllers;
    using Services.DataServices;
    using System.Threading.Tasks;
    using Services.Models.Images;

    public class ImagesController : BaseController
    {
        private readonly IImageService imagesService;

        public ImagesController(IImageService imagesService)
        {
            this.imagesService = imagesService;
        }

        [Authorize]
        public IActionResult AllByArticleId(int id)
        {
            var images = this.imagesService.GetAllByArticleId(id);
            var viewModel = new AllImagesViewModel
            {
                Images = images
            };
            return this.View(viewModel);
        }
    }
}
