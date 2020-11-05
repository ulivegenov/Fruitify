namespace Fruitify.Web.ViewModels.Administration.Contracts
{
    using Fruitify.Data.Models.Enums.Product;

    public interface IWebDetailsModel
    {
        int Id { get; set; }

        string Name { get; set; }

        string Image { get; set; }
    }
}
