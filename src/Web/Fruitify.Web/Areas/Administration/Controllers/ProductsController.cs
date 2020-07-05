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
    }
}
