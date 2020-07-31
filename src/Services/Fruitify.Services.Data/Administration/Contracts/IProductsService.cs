namespace Fruitify.Services.Data.Administration.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fruitify.Services.Data.Base.Contarcts;

    public interface IProductsService : IBaseService<int>
    {
        Task<IEnumerable<T>> GetAllWeekProductsAsync<T>();

        Task<T> GetDayProductAsync<T>();
    }
}
