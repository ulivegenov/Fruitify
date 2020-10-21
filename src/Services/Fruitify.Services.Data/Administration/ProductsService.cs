namespace Fruitify.Services.Data.Administration
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fruitify.Common;
    using Fruitify.Data.Common.Repositories;
    using Fruitify.Data.Models;
    using Fruitify.Data.Models.Enums.Product;
    using Fruitify.Services.Data.Administration.Contracts;
    using Fruitify.Services.Data.Base;
    using Fruitify.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class ProductsService : BaseService<Product, int>, IProductsService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;

        public ProductsService(IDeletableEntityRepository<Product> productsRepository)
            : base(productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task<IEnumerable<T>> GetAllProductsByTypeWithPagingAsync<T>(ProductType productType, int? take = null, int skip = 0)
        {
            var products = this.productsRepository.All()
                                                  .Where(p => p.Type.Equals(productType))
                                                  .To<T>()
                                                  .Skip(skip);

            if (take.HasValue)
            {
                products = products.Take(take.Value);
            }

            var result = await products.ToListAsync();

            return result.ToList();
        }

        public async Task<IEnumerable<T>> GetAllWeekProductsAsync<T>()
        {
            var weekProducts = await this.productsRepository.All()
                                                            .Where(p => p.WeekProduct == true)
                                                            .To<T>()
                                                            .Take(GlobalConstants.WeekProductsCount)
                                                            .ToListAsync();

            return weekProducts;
        }

        public override async Task<int> GetCountAsync(string type)
        {
            var products = await this.productsRepository.All()
                                                        .Where(p => p.Type.Equals(type))
                                                        .Select(p => p.Id)
                                                        .ToListAsync();
            var count = products.Count;

            return count;
        }

        public async Task<T> GetDayProductAsync<T>()
        {
            var dayProduct = await this.productsRepository.All()
                                                          .Where(p => p.DayProduct == true)
                                                          .To<T>()
                                                          .FirstOrDefaultAsync();

            return dayProduct;
        }
    }
}
