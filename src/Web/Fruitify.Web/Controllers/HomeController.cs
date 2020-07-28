namespace Fruitify.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Fruitify.Services.Data.Administration.Contracts;
    using Fruitify.Services.Mapping;
    using Fruitify.Web.ViewModels;
    using Fruitify.Web.ViewModels.Administration.Products;
    using Fruitify.Web.ViewModels.Main;
    using Frutify.Services.Models.Administration;
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
            var products = await this.productsService.GetAllAsync<ProductServiceDetailsModel>();
            var viewModel = new IndexWebModel();

            // Temporary code - TO DO method in ProductsService for extracting a DayProduct and WeekProducts
            var webProducts = products.Select(p => p.To<ProductWebDetailsModel>()).ToList();
            viewModel.DayProduct.Product = webProducts.FirstOrDefault();
            viewModel.WeekProducts.Products = webProducts.Take(4)
                                                         .ToList();

            return this.View(viewModel);
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
