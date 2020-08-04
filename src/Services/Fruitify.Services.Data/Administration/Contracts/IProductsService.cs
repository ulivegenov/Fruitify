namespace Fruitify.Services.Data.Administration.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fruitify.Data.Models.Enums.Product;
    using Fruitify.Services.Data.Base.Contarcts;

    public interface IProductsService : IBaseService<int>
    {
        Task<int> GetCountAsync(ProductType? productType);

        Task<IEnumerable<T>> GetAllWeekProductsAsync<T>();

        Task<IEnumerable<T>> GetAllProductsByTypeWithPagingAsync<T>(ProductType productType, int? take = null, int skip = 0);

        Task<T> GetDayProductAsync<T>();
    }
}
