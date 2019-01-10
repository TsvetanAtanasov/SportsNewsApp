namespace SportsNews.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Controllers;
    using Services.DataServices;
    using System.Threading.Tasks;
    using Models.Images;
    using Services.Models.Images;

    public class ImagesController : BaseController
    {
        private readonly IImageService imagesService;

        public ImagesController(IImageService imagesService)
        {
            this.imagesService = imagesService;
        }

        public IActionResult AllByArticleId(int id)
        {
            var images = this.imagesService.GetAllByArticleId(id);
            var viewModel = new AllImagesViewModel
            {
                Images = images
            };
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Create(int id)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id, CreateImageInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.imagesService.Create(id, model.ImageUrl);
            return this.RedirectToAction("AllByArticleId", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int imageId)
        {

            await this.imagesService.Delete(imageId);
            return this.RedirectToAction("AllByArticleId", new { id = id });
        }
    }
}
