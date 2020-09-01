namespace Fruitify.Web.ViewModels.Administration.Base
{
    using System.Collections.Generic;

    using Fruitify.Web.ViewModels.Administration.Contracts;

    public class BaseWebAllModel : IWebAllModel
    {
        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public ICollection<IWebDetailsModel> Entities { get; set; } = new List<IWebDetailsModel>();
    }
}
