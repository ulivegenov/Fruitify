namespace Fruitify.Services.Data.Administration
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fruitify.Common;
    using Fruitify.Data.Common.Repositories;
    using Fruitify.Data.Models;
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

        public async Task<IEnumerable<T>> GetAllWeekProducts<T>()
        {
            var weekProducts = await this.productsRepository.All()
                                                            .Where(p => p.WeekProduct == true)
                                                            .To<T>()
                                                            .Take(GlobalConstants.WeekProductsCount)
                                                            .ToListAsync();

            return weekProducts;
        }

        public async Task<T> GetDayProduct<T>()
        {
            var dayProduct = await this.productsRepository.All()
                                                          .Where(p => p.DayProduct == true)
                                                          .To<T>()
                                                          .FirstOrDefaultAsync();

            return dayProduct;
        }
    }
}
