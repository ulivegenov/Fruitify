namespace Fruitify.Services.Data.Administration
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fruitify.Data.Common.Repositories;
    using Fruitify.Data.Models;
    using Fruitify.Data.Models.Enums.Receipt;
    using Fruitify.Services.Data.Administration.Contracts;
    using Fruitify.Services.Data.Base;
    using Fruitify.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class ReceiptsService : BaseService<Receipt, int>, IReceiptsService
    {
        private readonly IDeletableEntityRepository<Receipt> receiptsRepository;

        public ReceiptsService(IDeletableEntityRepository<Receipt> receiptsRepository)
            : base(receiptsRepository)
        {
            this.receiptsRepository = receiptsRepository;
        }

        public override async Task<int> GetCountAsync(string type)
        {
            var receipts = await this.receiptsRepository.All()
                                                        .Where(r => r.Type.Equals(type))
                                                        .Select(r => r.Id)
                                                        .ToListAsync();

            var count = receipts.Count;

            return count;
        }

        public async Task<IEnumerable<T>> GetAllReceiptsByTypeWithPagingAsync<T>(ReceiptType receiptType, int? take = null, int skip = 0)
        {
            var products = this.receiptsRepository.All()
                                                  .Where(p => p.Type.Equals(receiptType))
                                                  .To<T>()
                                                  .Skip(skip);

            if (take.HasValue)
            {
                products = products.Take(take.Value);
            }

            var result = await products.ToListAsync();

            return result.ToList();
        }
    }
}
