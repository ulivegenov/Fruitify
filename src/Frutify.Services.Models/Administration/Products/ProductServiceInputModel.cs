namespace Fruitify.Services.Models.Administration.Products
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Fruitify.Common;
    using Fruitify.Data.Models;
    using Fruitify.Data.Models.Enums.Product;
    using Fruitify.Services.Mapping;
    using Fruitify.Services.Models.Contracts;

    public class ProductServiceInputModel : IServiceInputModel, IMapTo<Product>
    {
        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [StringLength(EntitiesAttributeConstraints.NameMaxLength, ErrorMessage = GlobalConstants.CharactersCountMessage, MinimumLength = EntitiesAttributeConstraints.NameMinLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        public ProductType Type { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Range(EntitiesAttributeConstraints.MinPrice, EntitiesAttributeConstraints.MaxPrice, ErrorMessage = GlobalConstants.InvalidRangeMessage)]
        public double Price { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [StringLength(EntitiesAttributeConstraints.UrlMaxLength, ErrorMessage = GlobalConstants.CharactersCountMessage, MinimumLength = EntitiesAttributeConstraints.UrlMinLength)]
        public string Image { get; set; }
    }
}
