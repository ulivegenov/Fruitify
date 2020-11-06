namespace Fruitify.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fruitify.Common;
    using Fruitify.Services.Data.Administration.Contracts;
    using Fruitify.Services.Mapping;
    using Fruitify.Services.Models.Administration.Receipts;
    using Fruitify.Web.ViewModels.Administration.Receipts;

    using Microsoft.AspNetCore.Mvc;

    public class ReceiptsController : BaseController
    {
        private readonly IReceiptsService receiptsService;

        public ReceiptsController(IReceiptsService receiptsService)
        {
            this.receiptsService = receiptsService;
        }

        public async Task<IActionResult> All(int id = 1)
        {
            var page = id;
            var receipts = await this.receiptsService
                                     .GetAllWithPagingAsync<ReceiptServiceDetailsModel>(
                                      GlobalConstants.ItemsPerPage, (page - 1) * GlobalConstants.ItemsPerPage);

            var viewModel = new ReceiptWebAllModel();

            this.AddReceiptsToViewModel(viewModel, receipts);

            viewModel.PagesCount = await this.GetPagesCount();

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        private async Task<int> GetPagesCount(string type = null)
        {
            var productsCount = type == null ? await this.receiptsService.GetCountAsync()
                                             : await this.receiptsService.GetCountAsync(type);

            var pagesCount = (int)Math.Ceiling((double)productsCount / GlobalConstants.ItemsPerPage);

            if (pagesCount == 0)
            {
                pagesCount = 1;
            }

            return pagesCount;
        }

        private void AddReceiptsToViewModel(ReceiptWebAllModel viewModel, IEnumerable<ReceiptServiceDetailsModel> products)
        {
            foreach (var product in products)
            {
                viewModel.Entities.Add(product.To<ReceiptWebDetailsModel>());
            }
        }
    }
}
