namespace Fruitify.Web.ViewModels.Administration.Products
{
    using Fruitify.Data.Models.Enums.Product;
    using Fruitify.Services.Mapping;
    using Frutify.Services.Models.Administration;

    public class ProductWebDetailsModel : IMapFrom<ProductServiceDetailsModel>
    {
        public string Name { get; set; }

        public ProductType Type { get; set; }

        public double Price { get; set; }

        public string Image { get; set; }

        public double PromoPrice { get; set; }

        public bool DayProduct { get; set; }

        public bool WeekProduct { get; set; }
    }
}
