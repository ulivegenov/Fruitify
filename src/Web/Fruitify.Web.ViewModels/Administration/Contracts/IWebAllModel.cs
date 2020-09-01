namespace Fruitify.Web.ViewModels.Administration.Contracts
{
    using System.Collections.Generic;

    public interface IWebAllModel
    {
        int CurrentPage { get; set; }

        int PagesCount { get; set; }

        ICollection<IWebDetailsModel> Entities { get; set; }
    }
}
