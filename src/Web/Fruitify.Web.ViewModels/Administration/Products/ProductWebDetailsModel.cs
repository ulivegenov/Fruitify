namespace Fruitify.Web.ViewModels.Administration.Products
{
    using System.ComponentModel.DataAnnotations;

    using Fruitify.Data.Models.Enums.Product;
    using Fruitify.Services.Mapping;
    using Frutify.Services.Models.Administration;

    public class ProductWebDetailsModel : IMapFrom<ProductServiceDetailsModel>
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Вид")]
        public ProductType Type { get; set; }

        [Display(Name = "Цена")]
        public double Price { get; set; }

        [Display(Name = "Снимка")]
        public string Image { get; set; }

        [Display(Name = "Промоционална цена")]
        public double PromoPrice { get; set; }

        [Display(Name = "Продукт на деня")]
        public bool DayProduct { get; set; }

        [Display(Name = "Продукт на седмицата")]
        public bool WeekProduct { get; set; }
    }
}
