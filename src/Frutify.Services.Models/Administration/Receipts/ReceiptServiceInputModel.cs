namespace Frutify.Services.Models.Administration.Receipts
{
    using System.ComponentModel.DataAnnotations;

    using Fruitify.Common;
    using Fruitify.Data.Models;
    using Fruitify.Data.Models.Enums.Receipt;
    using Fruitify.Services.Mapping;
    using Frutify.Services.Models.Contracts;

    public class ReceiptServiceInputModel : IServiceInputModel, IMapTo<Receipt>
    {
        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [StringLength(EntitiesAttributeConstraints.NameMaxLength, ErrorMessage = GlobalConstants.CharactersCountMessage, MinimumLength = EntitiesAttributeConstraints.NameMinLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        public ReceiptType Type { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [StringLength(EntitiesAttributeConstraints.DescriptionMaxLength, ErrorMessage = GlobalConstants.CharactersCountMessage, MinimumLength = EntitiesAttributeConstraints.DescriptionMinLength)]

        public string Description { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        public string Image { get; set; }
    }
}
