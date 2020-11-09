namespace Fruitify.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Fruitify.Services.Data.Administration.Contracts;
    using Fruitify.Services.Mapping;
    using Fruitify.Services.Models.Administration.Products;
    using Fruitify.Web.ViewModels;
    using Fruitify.Web.ViewModels.Administration.Products;
    using Fruitify.Web.ViewModels.Main.Home;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexWebModel();

            var webProducts = await this.productsService.GetAllWeekProductsAsync<ProductServiceDetailsModel>();
            var dayProduct = await this.productsService.GetDayProductAsync<ProductServiceDetailsModel>();
            viewModel.DayProduct.Product = dayProduct?.To<ProductWebDetailsModel>();
            viewModel.WeekProducts.Products = webProducts?.Select(p => p.To<ProductWebDetailsModel>()).ToList();

            return this.View(viewModel);
        }

        public IActionResult Contacts()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
