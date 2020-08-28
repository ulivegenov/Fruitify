namespace Fruitify.Services.Data.Administration
{
    using Fruitify.Data.Common.Repositories;
    using Fruitify.Data.Models;
    using Fruitify.Services.Data.Administration.Contracts;
    using Fruitify.Services.Data.Base;

    public class ReceiptsService : BaseService<Receipt, int>, IReceiptsService
    {
        private readonly IDeletableEntityRepository<Receipt> receiptsRepository;

        public ReceiptsService(IDeletableEntityRepository<Receipt> receiptsRepository)
            : base(receiptsRepository)
        {
            this.receiptsRepository = receiptsRepository;
        }
    }
}
