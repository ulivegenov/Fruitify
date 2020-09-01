namespace Fruitify.Web.ViewModels.Administration.Contracts
{
    using Microsoft.AspNetCore.Http;

    public interface IWebInputModel
    {
        string Name { get; set; }

        IFormFile Image { get; set; }
    }
}
