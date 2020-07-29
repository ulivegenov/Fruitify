﻿namespace Frutify.Services.Models.Administration
{
    using Fruitify.Data.Models;
    using Fruitify.Data.Models.Enums.Product;
    using Fruitify.Services.Mapping;

    public class ProductServiceDetailsModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProductType Type { get; set; }

        public double Price { get; set; }

        public string Image { get; set; }

        public double PromoPrice { get; set; }

        public bool DayProduct { get; set; }

        public bool WeekProduct { get; set; }
    }
}
