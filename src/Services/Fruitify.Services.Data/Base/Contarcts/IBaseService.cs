namespace Fruitify.Services.Data.Base.Contarcts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Frutify.Services.Models.Contracts;

    public interface IBaseService<TKey>
    {
        Task<int> CreateAsync(IServiceInputModel servicesInputViewModel);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetAllWithPagingAsync<T>(int? take = null, int skip = 0);

        Task<T> GetByIdAsync<T>(TKey id);

        Task<int> GetCountAsync();

        Task<int> GetCountAsync(string type);

        Task<int> EditAsync(IServiceDetailsModel<TKey> serviceDetailsModel);

        Task<int> DeleteByIdAsync(TKey id);
    }
}
