namespace Fruitify.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fruitify.Common;
    using Fruitify.Data.Models.Enums.Product;
    using Fruitify.Services.Data.Administration.Contracts;
    using Fruitify.Services.Mapping;
    using Fruitify.Web.ViewModels.Administration.Products;
    using Frutify.Services.Models.Administration.Products;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<IActionResult> All(int id = 1)
        {
            var page = id;
            var products = await this.productsService
                                     .GetAllWithPagingAsync<ProductServiceDetailsModel>(
                                      GlobalConstants.ItemsPerPage, (page - 1) * GlobalConstants.ItemsPerPage);

            var viewModel = new ProductWebAllModel();

            this.AddProductsToViewModel(viewModel, products);

            viewModel.PagesCount = await this.GetPagesCount();

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        public async Task<IActionResult> AllFruits(int id = 1)
        {
            var page = id;
            var products = await this.productsService
                                     .GetAllProductsByTypeWithPagingAsync<ProductServiceDetailsModel>(
                                      ProductType.Fruit, GlobalConstants.ItemsPerPage, (page - 1) * GlobalConstants.ItemsPerPage);

            var viewModel = new ProductWebAllModel();

            this.AddProductsToViewModel(viewModel, products);

            viewModel.PagesCount = await this.GetPagesCount(ProductType.Fruit);

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        public async Task<IActionResult> AllVegetables(int id = 1)
        {
            var page = id;
            var products = await this.productsService
                                     .GetAllProductsByTypeWithPagingAsync<ProductServiceDetailsModel>(
                                      ProductType.Vegetable, GlobalConstants.ItemsPerPage, (page - 1) * GlobalConstants.ItemsPerPage);

            var viewModel = new ProductWebAllModel();

            this.AddProductsToViewModel(viewModel, products);

            viewModel.PagesCount = await this.GetPagesCount(ProductType.Vegetable);

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        private async Task<int> GetPagesCount(ProductType? productType = null)
        {
            var productsCount = productType == null ? await this.productsService.GetCountAsync()
                                                    : await this.productsService.GetCountAsync(productType);

            var pagesCount = (int)Math.Ceiling((double)productsCount / GlobalConstants.ItemsPerPage);

            if (pagesCount == 0)
            {
                pagesCount = 1;
            }

            return pagesCount;
        }

        private void AddProductsToViewModel(ProductWebAllModel viewModel, IEnumerable<ProductServiceDetailsModel> products)
        {
            foreach (var product in products)
            {
                viewModel.Products.Add(product.To<ProductWebDetailsModel>());
            }
        }
    }
}
