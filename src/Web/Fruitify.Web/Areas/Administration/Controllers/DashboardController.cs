namespace Fruitify.Web.Areas.Administration.Controllers
{
    using Fruitify.Services.Data;
    using Fruitify.Web.Controllers;
    using Fruitify.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdminBaseController
    {
        private readonly ISettingsService settingsService;

        public DashboardController(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
        }
    }
}
