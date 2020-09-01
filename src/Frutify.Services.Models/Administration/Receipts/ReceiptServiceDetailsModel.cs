namespace Frutify.Services.Models.Administration.Receipts
{
    using Fruitify.Data.Models.Enums.Product;
    using Frutify.Services.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ReceiptServiceDetailsModel : IServiceDetailsModel<int>
    {
        public int Id { get; set; }
        public string Name { get; set ; }
        public ProductType Type { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public double PromoPrice { get; set; }
        public bool DayProduct { get; set; }
        public bool WeekProduct { get; set; }
    }
}
