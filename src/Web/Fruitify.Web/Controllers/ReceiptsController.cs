namespace Fruitify.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fruitify.Common;
    using Fruitify.Data.Models.Enums.Receipt;
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

        public async Task<IActionResult> All()
        {
            var viewModel = await this.AllReceipts();
            this.ViewData["TableTitle"] = GlobalConstants.AllReceiptsTitleConst;

            return this.View(viewModel);
        }

        public async Task<IActionResult> AllJuices()
        {
            var viewModel = await this.AllReceiptsByType(ReceiptType.Juice);
            this.ViewData["TableTitle"] = GlobalConstants.AllJuicesTitleConst;

            return this.View(viewModel);
        }

        public async Task<IActionResult> AllSalads()
        {
            var viewModel = await this.AllReceiptsByType(ReceiptType.Salad);
            this.ViewData["TableTitle"] = GlobalConstants.AllSaladsTitleConst;

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

        private void AddEntitiesToViewModel(ReceiptWebAllModel viewModel, IEnumerable<ReceiptServiceDetailsModel> products)
        {
            foreach (var product in products)
            {
                viewModel.Entities.Add(product.To<ReceiptWebDetailsModel>());
            }
        }

        private async Task<ReceiptWebAllModel> AllReceipts(int id = 1)
        {
            var page = id;
            var receipts = await this.receiptsService
                                     .GetAllWithPagingAsync<ReceiptServiceDetailsModel>(
                                      GlobalConstants.ItemsPerPageAdmin, (page - 1) * GlobalConstants.ItemsPerPageAdmin);

            var viewModel = new ReceiptWebAllModel();

            this.AddEntitiesToViewModel(viewModel, receipts);

            viewModel.PagesCount = await this.GetPagesCount();

            viewModel.CurrentPage = page;

            return viewModel;
        }

        private async Task<ReceiptWebAllModel> AllReceiptsByType(ReceiptType receiptType, int id = 1)
        {
            var page = id;
            var receipts = await this.receiptsService
                                     .GetAllReceiptsByTypeWithPagingAsync<ReceiptServiceDetailsModel>(
                                      receiptType, GlobalConstants.ItemsPerPageAdmin, (page - 1) * GlobalConstants.ItemsPerPageAdmin);

            var viewModel = new ReceiptWebAllModel();

            this.AddEntitiesToViewModel(viewModel, receipts);

            viewModel.PagesCount = await this.GetPagesCount(receiptType.ToString());

            viewModel.CurrentPage = page;

            return viewModel;
        }
    }
}
