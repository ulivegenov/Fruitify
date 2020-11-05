namespace Fruitify.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Fruitify.Common;
    using Fruitify.Data.Models;
    using Fruitify.Services.Data.Administration.Contracts;
    using Fruitify.Services.Data.AppServices.Contracts;
    using Fruitify.Web.ViewModels.Administration.Receipts;
    using Frutify.Services.Models.Administration.Receipts;

    using Microsoft.AspNetCore.Mvc;

    public class ReceiptsController : AdministrationController<Receipt, ReceiptWebInputModel,
                                                               ReceiptServiceInputModel, ReceiptServiceDetailsModel,
                                                               ReceiptWebAllModel, ReceiptWebDetailsModel>
    {
        private readonly IReceiptsService receiptsService;
        private readonly ICloudinaryService cloudinaryService;

        public ReceiptsController(
                                  IReceiptsService receiptsService,
                                  ICloudinaryService cloudinaryService)
            : base(receiptsService, cloudinaryService)
        {
            this.receiptsService = receiptsService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpPost]
        [Route("/Administration/Receipts/Details/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!(await this.receiptsService.DeleteByIdAsync(id) > 0))
            {
                this.TempData["Error"] = GlobalConstants.DeleteProductErrorMessage;

                return this.View();
            }

            return this.Redirect("/Administration/Receipts/All");
        }

        protected override async Task<int> GetPagesCount(string type = null)
        {
            var receiptsCount = type == null ? await this.receiptsService.GetCountAsync()
                                             : await this.receiptsService.GetCountAsync(type);

            var pagesCount = (int)Math.Ceiling((double)receiptsCount / GlobalConstants.ItemsPerPageAdmin);

            if (pagesCount == 0)
            {
                pagesCount = 1;
            }

            return pagesCount;
        }
    }
}
