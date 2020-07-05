namespace Fruitify.Services.Data.Base.Contarcts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Frutify.Services.Models.Contracts;

    public interface IBaseService<TKey>
    {
        Task<int> CreateAsync(IServiceInputModel servicesInputViewModel);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(TKey id);

        Task<int> EditAsync(IServiceDetailsModel<TKey> serviceDetailsModel);

        Task<int> DeleteByIdAsync(TKey id);
    }
}
