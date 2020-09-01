﻿using Fruitify.Data.Models.Enums.Product;

namespace Frutify.Services.Models.Contracts
{
    public interface IServiceDetailsModel<TKey>
    {
        public TKey Id { get; set; }

        string Name { get; set; }

        ProductType Type { get; set; }

        double Price { get; set; }

        string Image { get; set; }

        double PromoPrice { get; set; }

        bool DayProduct { get; set; }

        bool WeekProduct { get; set; }
    }
}
