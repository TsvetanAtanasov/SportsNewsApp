namespace SportsNews.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Controllers;
    using SportsNews.Services.DataServices;
    using SportsNews.Web.Areas.Admin.Models;
    using System.Threading.Tasks;

    public class ImagesController : BaseController
    {
        private readonly IImageService imagesService;

        public ImagesController(IImageService imagesService)
        {
            this.imagesService = imagesService;
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
        public async Task<IActionResult> Create(int id, CreateImageInputModel model)
        {
            if (this.User.IsInRole("Administrator"))
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(model);
                }
                await this.imagesService.Create(id, model.ImageUrl);
            }
            return this.RedirectToAction("AllByArticleId", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int imageId)
        {
            if (this.User.IsInRole("Administrator"))
            {
                await this.imagesService.Delete(imageId);
            }
            return this.RedirectToAction("AllByArticleId", new { id = id });
        }
    }
}
