namespace Fruitify.Services.Data.Administration
{
    using Fruitify.Data.Common.Repositories;
    using Fruitify.Data.Models;
    using Fruitify.Services.Data.Administration.Contracts;
    using Fruitify.Services.Data.Base;

    public class ProductsService : BaseService<Product, int>, IProductsService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;

        public ProductsService(IDeletableEntityRepository<Product> productsRepository)
            : base(productsRepository)
        {
            this.productsRepository = productsRepository;
        }
    }
}
