namespace Fruitify.Services.Data.Administration
{
    using System.Linq;
    using System.Threading.Tasks;

    using Fruitify.Data.Common.Repositories;
    using Fruitify.Data.Models;
    using Fruitify.Services.Data.Administration.Contracts;
    using Fruitify.Services.Data.Base;
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
                                                        .Where(r => r.Type.ToString().Equals(type))
                                                        .Select(r => r.Id)
                                                        .ToListAsync();

            var count = receipts.Count;

            return count;
        }
    }
}
