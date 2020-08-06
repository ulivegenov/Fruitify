namespace Fruitify.Web.ViewModels.Main.Home
{
    public class IndexWebModel
    {
        public DayProductWebModel DayProduct { get; set; } = new DayProductWebModel();

        public WeekProductsWebModel WeekProducts { get; set; } = new WeekProductsWebModel();
    }
}
