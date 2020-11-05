namespace Fruitify.Web.ViewModels.Administration.Receipts
{
    using System.ComponentModel.DataAnnotations;

    using Fruitify.Common;
    using Fruitify.Data.Models.Enums.Receipt;
    using Fruitify.Services.Mapping;
    using Fruitify.Web.ViewModels.Administration.Contracts;
    using Frutify.Services.Models.Administration.Receipts;

    public class ReceiptWebDetailsModel : IMapFrom<ReceiptServiceDetailsModel>, IMapTo<ReceiptServiceDetailsModel>, IWebDetailsModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [StringLength(EntitiesAttributeConstraints.NameMaxLength, ErrorMessage = GlobalConstants.CharactersCountMessage, MinimumLength = EntitiesAttributeConstraints.NameMinLength)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Display(Name = "Вид рецепта")]
        public ReceiptType Type { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [StringLength(EntitiesAttributeConstraints.DescriptionMaxLength, ErrorMessage = GlobalConstants.CharactersCountMessage, MinimumLength = EntitiesAttributeConstraints.DescriptionMinLength)]
        [Display(Name = "Съдържание на рецептата")]
        public string Description { get; set; }
    }
}
