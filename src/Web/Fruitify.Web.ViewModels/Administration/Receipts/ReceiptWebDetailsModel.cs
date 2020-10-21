namespace Fruitify.Web.ViewModels.Administration.Receipts
{
    using Fruitify.Data.Models.Enums.Product;
    using Fruitify.Services.Mapping;
    using Fruitify.Web.ViewModels.Administration.Contracts;
    using Frutify.Services.Models.Administration.Receipts;

    public class ReceiptWebDetailsModel : IMapFrom<ReceiptServiceDetailsModel>, IMapTo<ReceiptServiceDetailsModel>, IWebDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProductType Type { get; set; }

        public double Price { get; set; }

        public double PromoPrice { get; set; }

        public bool DayProduct { get; set; }

        public bool WeekProduct { get; set; }

        public string Image { get; set; }
    }
}
