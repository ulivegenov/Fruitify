namespace Fruitify.Services.Data.Administration.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fruitify.Data.Models.Enums.Receipt;
    using Fruitify.Services.Data.Base.Contarcts;

    public interface IReceiptsService : IBaseService<int>
    {
        Task<IEnumerable<T>> GetAllReceiptsByTypeWithPagingAsync<T>(ReceiptType receiptType, int? take = null, int skip = 0);
    }
}
