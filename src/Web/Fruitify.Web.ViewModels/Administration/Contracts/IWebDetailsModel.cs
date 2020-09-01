namespace Fruitify.Web.ViewModels.Administration.Contracts
{
    using Fruitify.Data.Models.Enums.Product;

    public interface IWebDetailsModel
    {
        int Id { get; set; }

        string Name { get; set; }

        ProductType Type { get; set; }

        double Price { get; set; }

        double PromoPrice { get; set; }

        bool DayProduct { get; set; }

        bool WeekProduct { get; set; }

        string Image { get; set; }
    }
}
