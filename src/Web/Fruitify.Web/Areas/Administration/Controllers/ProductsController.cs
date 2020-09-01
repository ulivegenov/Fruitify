namespace Fruitify.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fruitify.Common;
    using Fruitify.Data.Models;
    using Fruitify.Data.Models.Enums.Product;
    using Fruitify.Services.Data.Administration.Contracts;
    using Fruitify.Services.Data.AppServices.Contracts;
    using Fruitify.Services.Mapping;
    using Fruitify.Web.ViewModels.Administration.Products;
    using Frutify.Services.Models.Administration.Products;
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

        public async Task<IActionResult> AllFruits(int id = 1)
        {
            var page = id;
            var products = await this.productsService
                                     .GetAllProductsByTypeWithPagingAsync<ProductServiceDetailsModel>(
                                      ProductType.Fruit, GlobalConstants.ItemsPerPageAdmin, (page - 1) * GlobalConstants.ItemsPerPageAdmin);

            var viewModel = new ProductWebAllModel();

            this.AddProductsToViewModel(viewModel, products);

            viewModel.PagesCount = await this.GetPagesCount(ProductType.Fruit.ToString());

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        public async Task<IActionResult> AllVegetables(int id = 1)
        {
            var page = id;
            var products = await this.productsService
                                     .GetAllProductsByTypeWithPagingAsync<ProductServiceDetailsModel>(
                                      ProductType.Vegetable, GlobalConstants.ItemsPerPageAdmin, (page - 1) * GlobalConstants.ItemsPerPageAdmin);

            var viewModel = new ProductWebAllModel();

            this.AddProductsToViewModel(viewModel, products);

            viewModel.PagesCount = await this.GetPagesCount(ProductType.Vegetable.ToString());

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await this.productsService.GetByIdAsync<ProductServiceDetailsModel>(id);
            var viewModel = product.To<ProductWebDetailsModel>();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductWebDetailsModel productEditModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(productEditModel);
            }

            var serviceProduct = productEditModel.To<ProductServiceDetailsModel>();

            await this.productsService.EditAsync(serviceProduct);

            return this.Redirect($"/Administration/Products/Details/{serviceProduct.Id}");
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
    }
}
