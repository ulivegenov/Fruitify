namespace Fruitify.Services.Data.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fruitify.Common;
    using Fruitify.Data.Common.Models;
    using Fruitify.Data.Common.Repositories;
    using Fruitify.Services.Data.Base.Contarcts;
    using Fruitify.Services.Mapping;
    using Fruitify.Services.Models.Contracts;

    using Microsoft.EntityFrameworkCore;

    public abstract class BaseService<TEntity, TKey> : IBaseService<TKey>
        where TEntity : BaseDeletableModel<TKey>
    {
        private readonly IDeletableEntityRepository<TEntity> deletableEntityRepository;

        public BaseService(IDeletableEntityRepository<TEntity> deletableEntityRepository)
        {
            this.deletableEntityRepository = deletableEntityRepository;
        }

        public async Task<int> CreateAsync(IServiceInputModel servicesInputViewModel)
        {
            var entity = servicesInputViewModel.To<TEntity>();

            await this.deletableEntityRepository.AddAsync(entity);
            var result = await this.deletableEntityRepository.SaveChangesAsync();

            return result;
        }

        public async Task<int> DeleteByIdAsync(TKey id)
        {
            var entity = await this.deletableEntityRepository.GetByIdWithDeletedAsync(id);

            if (entity == null)
            {
                throw new ArgumentNullException(string.Format(GlobalConstants.InvalidTEntityIdErrorMessage, nameof(TEntity), id));
            }

            this.deletableEntityRepository.Delete(entity);
            var result = await this.deletableEntityRepository.SaveChangesAsync();

            return result;
        }

        public async Task<int> EditAsync(IServiceDetailsModel<TKey> serviceDetailsModel)
        {
            var entity = serviceDetailsModel.To<TEntity>();

            this.deletableEntityRepository.Update(entity);
            var result = await this.deletableEntityRepository.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var entities = await this.deletableEntityRepository.All()
                                                               .To<T>()
                                                               .ToListAsync();

            return entities;
        }

        public async Task<IEnumerable<T>> GetAllWithPagingAsync<T>(int? take = null, int skip = 0)
        {
            var entities = this.deletableEntityRepository.All()
                                                         .Skip(skip);

            if (take.HasValue)
            {
                entities = entities.Take(take.Value);
            }

            var result = await entities.ToListAsync();

            return result.Select(c => c.To<T>()).ToList();
        }

        public async Task<T> GetByIdAsync<T>(TKey id)
        {
            var entity = await this.deletableEntityRepository.All()
                                                             .Where(e => id.Equals(e.Id))
                                                             .FirstOrDefaultAsync();

            var entityServiceModel = entity.To<T>();

            return entityServiceModel;
        }

        public async Task<int> GetCountAsync()
        {
            var deletableEntities = await this.deletableEntityRepository.All()
                                                                        .Select(e => e.Id)
                                                                        .ToListAsync();
            var count = deletableEntities.Count;

            return count;
        }

        public abstract Task<int> GetCountAsync(string type);
    }
}
