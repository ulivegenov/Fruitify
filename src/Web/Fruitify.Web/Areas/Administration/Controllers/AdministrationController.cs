namespace Fruitify.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fruitify.Common;
    using Fruitify.Data.Common.Models;
    using Fruitify.Services.Data.AppServices.Contracts;
    using Fruitify.Services.Data.Base.Contarcts;
    using Fruitify.Services.Mapping;
    using Fruitify.Web.ViewModels.Administration.Base;
    using Fruitify.Web.ViewModels.Administration.Contracts;
    using Frutify.Services.Models.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public abstract class AdministrationController<TEntity, TEntityWebInputModel, TEntityServiceInputModel,
                                                   TEntityServiceDetailsModel, TEntityWebAllModel,
                                                   TEntityWebDetailsModel> : AdminBaseController
        where TEntity : BaseDeletableModel<int>
        where TEntityServiceInputModel : IServiceInputModel
        where TEntityWebInputModel : IWebInputModel
        where TEntityServiceDetailsModel : IServiceDetailsModel<int>
        where TEntityWebAllModel : IWebAllModel
        where TEntityWebDetailsModel : IWebDetailsModel
    {
        private readonly IBaseService<int> entityService;
        private readonly ICloudinaryService cloudinaryService;

        public AdministrationController(
                                        IBaseService<int> entityService,
                                        ICloudinaryService cloudinaryService)
        {
            this.entityService = entityService;
            this.cloudinaryService = cloudinaryService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TEntityWebInputModel entityWebInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(entityWebInputModel);
            }

            var entityServiceModel = entityWebInputModel.To<TEntityServiceInputModel>();
            var imageUrl = await this.cloudinaryService.UploadImageAsync(
                                                                         entityWebInputModel.Image,
                                                                         $"{entityServiceModel.Name}",
                                                                         string.Format(GlobalConstants.ImagesFolder, typeof(TEntity).Name));
            entityServiceModel.Image = imageUrl;

            await this.entityService.CreateAsync(entityServiceModel);

            return this.Redirect("/Administration/Dashboard");
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await this.entityService.GetByIdAsync<TEntityServiceDetailsModel>(id);
            var viewModel = product.To<TEntityWebDetailsModel>();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TEntityWebDetailsModel entityEditModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(entityEditModel);
            }

            var serviceTEntity = entityEditModel.To<TEntityServiceDetailsModel>();

            await this.entityService.EditAsync(serviceTEntity);

            return this.Redirect($"/Administration/{typeof(TEntity).Name}s/All");
        }

        public async Task<IActionResult> All(TEntityWebAllModel viewModel, int id = 1)
        {
            var page = id;
            var entities = await this.entityService
                                     .GetAllWithPagingAsync<TEntityServiceDetailsModel>(
                                      GlobalConstants.ItemsPerPageAdmin, (page - 1) * GlobalConstants.ItemsPerPageAdmin);

            this.AddProductsToViewModel(viewModel, entities);

            viewModel.PagesCount = await this.GetPagesCount();

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        protected void AddProductsToViewModel(TEntityWebAllModel viewModel, IEnumerable<TEntityServiceDetailsModel> entities)
        {
            foreach (var entity in entities)
            {
                viewModel.Entities.Add(entity.To<TEntityWebDetailsModel>());
            }
        }

        protected abstract Task<int> GetPagesCount(string type = null);
    }
}
