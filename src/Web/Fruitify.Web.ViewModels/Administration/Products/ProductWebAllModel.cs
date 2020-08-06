namespace Fruitify.Web.ViewModels.Administration.Products
{
    using System.Collections.Generic;

    using Fruitify.Web.ViewModels.Main.Home;

    public class ProductWebAllModel
    {
        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public List<ProductWebDetailsModel> Products { get; set; } = new List<ProductWebDetailsModel>();
    }
}
