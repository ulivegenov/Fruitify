namespace Fruitify.Web.ViewModels.Administration.Receipts
{
    using Fruitify.Data.Models.Enums.Product;
    using Fruitify.Web.ViewModels.Administration.Contracts;

    public class ReceiptWebDetailsModel : IWebDetailsModel
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
