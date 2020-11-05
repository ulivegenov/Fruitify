namespace Frutify.Services.Models.Administration.Receipts
{
    using Fruitify.Data.Models;
    using Fruitify.Data.Models.Enums.Receipt;
    using Fruitify.Services.Mapping;
    using Frutify.Services.Models.Contracts;

    public class ReceiptServiceDetailsModel : IMapTo<Receipt>, IMapFrom<Receipt>, IServiceDetailsModel<int>
    {
        public int Id { get; set; }

        public string Name { get; set ; }

        public ReceiptType Type { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }
    }
}
