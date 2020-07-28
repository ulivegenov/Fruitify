﻿namespace Fruitify.Web.ViewModels.Main
{
    using System.Collections.Generic;

    using Fruitify.Web.ViewModels.Administration.Products;

    public class WeekProductsWebModel
    {
        public List<ProductWebDetailsModel> Products { get; set; } = new List<ProductWebDetailsModel>();
    }
}
