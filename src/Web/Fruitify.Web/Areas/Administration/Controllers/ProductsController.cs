namespace Fruitify.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fruitify.Common;
    using Fruitify.Services.Data.Administration.Contracts;
    using Fruitify.Services.Data.AppServices.Contracts;
    using Fruitify.Services.Mapping;
    using Fruitify.Web.ViewModels.Administration.Products;
    using Frutify.Services.Models.Administration;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : AdministrationController
    {
        private readonly IProductsService productsService;
        private readonly ICloudinaryService cloudinaryService;

        public ProductsController(
                                  IProductsService productsService,
                                  ICloudinaryService cloudinaryService)
        {
            this.productsService = productsService;
            this.cloudinaryService = cloudinaryService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductWebInputModel productWebInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(productWebInputModel);
            }

            var productServiceModel = productWebInputModel.To<ProductServiceInputModel>();
            var imageUrl = await this.cloudinaryService.UploadImageAsync(
                                                                         productWebInputModel.Image,
                                                                         $"{productServiceModel.Name}",
                                                                         GlobalConstants.ProductsImagesFolder);
            productServiceModel.Image = imageUrl;

            await this.productsService.CreateAsync(productServiceModel);

            return this.Redirect("/Administration/Dashboard");
        }

        public async Task<IActionResult> All(int id = 1)
        {
            var page = id;
            var products = await this.productsService
                                     .GetAllWithPagingAsync<ProductServiceDetailsModel>(GlobalConstants.ItemsPerPageAdmin, (page - 1) * GlobalConstants.ItemsPerPageAdmin);

            var viewModel = new ProductWebAllModel();

            foreach (var product in products)
            {
                viewModel.Products.Add(product.To<ProductWebDetailsModel>());
            }

            var count = await this.productsService.GetCountAsync();
            viewModel.PagesCount = (int)Math.Ceiling((double)count / GlobalConstants.ItemsPerPageAdmin);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await this.productsService.GetByIdAsync<ProductServiceDetailsModel>(id);
            var viewModel = product.To<ProductWebDetailsModel>();

            return this.View(viewModel);
        }
    }
}
