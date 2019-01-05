namespace SportsNews.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Controllers;
    using Services.DataServices;
    using System.Threading.Tasks;
    using Models.Images;

    public class ImagesController : BaseController
    {
        private readonly IImageService imagesService;

        public ImagesController(IImageService imagesService)
        {
            this.imagesService = imagesService;
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
            return this.RedirectToAction("Details", "Articles", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            await this.imagesService.Delete(id);
            return this.RedirectToAction("Details", "Articles", new { id = id });
        }
    }
}
