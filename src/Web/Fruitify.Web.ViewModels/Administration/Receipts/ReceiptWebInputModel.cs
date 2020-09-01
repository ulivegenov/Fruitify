namespace Fruitify.Web.ViewModels.Administration.Receipts
{
    using System.ComponentModel.DataAnnotations;

    using Fruitify.Common;
    using Fruitify.Data.Models.Enums.Receipt;
    using Fruitify.Services.Mapping;
    using Fruitify.Web.ViewModels.Administration.Contracts;
    using Frutify.Services.Models.Administration.Receipts;

    using Microsoft.AspNetCore.Http;

    public class ReceiptWebInputModel : IMapTo<ReceiptServiceInputModel>, IWebInputModel
    {
        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [StringLength(EntitiesAttributeConstraints.NameMaxLength, ErrorMessage = GlobalConstants.CharactersCountMessage, MinimumLength = EntitiesAttributeConstraints.NameMinLength)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Display(Name = "Вид рецепта")]
        public ReceiptType Type { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [StringLength(EntitiesAttributeConstraints.DescriptionMaxLength, ErrorMessage = GlobalConstants.CharactersCountMessage, MinimumLength = EntitiesAttributeConstraints.DescriptionMinLength)]
        [Display(Name = "Съдържание на рецептата")]
        public string Description { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Display(Name = "Избери снимка")]
        public virtual IFormFile Image { get; set; }
    }
}
