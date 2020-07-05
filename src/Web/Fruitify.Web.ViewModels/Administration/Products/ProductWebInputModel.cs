namespace Fruitify.Web.ViewModels.Administration.Products
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Fruitify.Common;
    using Fruitify.Data.Models.Enums.Product;
    using Fruitify.Services.Mapping;
    using Frutify.Services.Models.Administration;

    using Microsoft.AspNetCore.Http;

    public class ProductWebInputModel : IMapTo<ProductServiceInputModel>
    {
        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [StringLength(EntitiesAttributeConstraints.NameMaxLength, ErrorMessage = GlobalConstants.CharactersCountMessage, MinimumLength = EntitiesAttributeConstraints.NameMinLength)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Display(Name = "Вид на продукта")]
        public ProductType Type { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Range(EntitiesAttributeConstraints.MinPrice, EntitiesAttributeConstraints.MaxPrice, ErrorMessage = GlobalConstants.InvalidRangeMessage)]
        [Display(Name = "Цена")]
        public double Price { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Display(Name = "Избери снимка")]
        public virtual IFormFile Image { get; set; }
    }
}
