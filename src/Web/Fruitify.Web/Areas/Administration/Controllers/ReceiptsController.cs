namespace Fruitify.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Fruitify.Common;
    using Fruitify.Services.Data.Administration.Contracts;
    using Fruitify.Services.Data.AppServices.Contracts;
    using Fruitify.Services.Mapping;
    using Fruitify.Web.ViewModels.Administration.Receipts;
    using Frutify.Services.Models.Administration.Receipts;
    using Microsoft.AspNetCore.Mvc;

    public class ReceiptsController : AdministrationController
    {
        private readonly IReceiptsService receiptsService;
        private readonly ICloudinaryService cloudinaryService;

        public ReceiptsController(
                                  IReceiptsService receiptsService,
                                  ICloudinaryService cloudinaryService)
        {
            this.receiptsService = receiptsService;
            this.cloudinaryService = cloudinaryService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReceiptWebInputModel receiptWebInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(receiptWebInputModel);
            }

            var receiptServiceModel = receiptWebInputModel.To<ReceiptServiceInputModel>();
            var imageUrl = await this.cloudinaryService.UploadImageAsync(
                                                                         receiptWebInputModel.Image,
                                                                         $"{receiptServiceModel.Name}",
                                                                         GlobalConstants.ReceiptsImagesFolder);
            receiptServiceModel.Image = imageUrl;

            await this.receiptsService.CreateAsync(receiptServiceModel);

            return this.Redirect("/Administration/Dashboard");
        }
    }
}
