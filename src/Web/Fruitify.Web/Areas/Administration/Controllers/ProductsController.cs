namespace Fruitify.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Fruitify.Common;
    using Fruitify.Data.Models;
    using Fruitify.Data.Models.Enums.Product;
    using Fruitify.Services.Data.Administration.Contracts;
    using Fruitify.Services.Data.AppServices.Contracts;
    using Fruitify.Services.Models.Administration.Products;
    using Fruitify.Web.ViewModels.Administration.Products;

    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : AdministrationController<Product, ProductWebInputModel,
                                                               ProductServiceInputModel, ProductServiceDetailsModel,
                                                               ProductWebAllModel, ProductWebDetailsModel>
    {
        private readonly IProductsService productsService;
        private readonly ICloudinaryService cloudinaryService;

        public ProductsController(
                                  IProductsService productsService,
                                  ICloudinaryService cloudinaryService)
            : base(productsService, cloudinaryService)
        {
            this.productsService = productsService;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<IActionResult> AllFruits()
        {
            var viewModel = await this.AllProductsByType(ProductType.Fruit);

            return this.View(viewModel);
        }

        public async Task<IActionResult> AllVegetables()
        {
            var viewModel = await this.AllProductsByType(ProductType.Vegetable);

            return this.View(viewModel);
        }

        [HttpPost]
        [Route("/Administration/Products/Details/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!(await this.productsService.DeleteByIdAsync(id) > 0))
            {
                this.TempData["Error"] = GlobalConstants.DeleteProductErrorMessage;

                return this.View();
            }

            return this.Redirect("/Administration/Products/All");
        }

        protected override async Task<int> GetPagesCount(string type = null)
        {
            var productsCount = type == null ? await this.productsService.GetCountAsync()
                                             : await this.productsService.GetCountAsync(type);

            var pagesCount = (int)Math.Ceiling((double)productsCount / GlobalConstants.ItemsPerPageAdmin);

            if (pagesCount == 0)
            {
                pagesCount = 1;
            }

            return pagesCount;
        }

        private async Task<ProductWebAllModel> AllProductsByType(ProductType productType, int id = 1)
        {
            var page = id;
            var products = await this.productsService
                                     .GetAllProductsByTypeWithPagingAsync<ProductServiceDetailsModel>(
                                      productType, GlobalConstants.ItemsPerPageAdmin, (page - 1) * GlobalConstants.ItemsPerPageAdmin);

            var viewModel = new ProductWebAllModel();

            this.AddEntitiesToViewModel(viewModel, products);

            viewModel.PagesCount = await this.GetPagesCount(productType.ToString());

            viewModel.CurrentPage = page;

            return viewModel;
        }
    }
}
