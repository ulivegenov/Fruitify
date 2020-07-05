namespace Fruitify.Web.ViewModels.Administration.Products
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Fruitify.Common;
    using Fruitify.Data.Models.Enums.Product;
    using Fruitify.Services.Mapping;
    using Frutify.Services.Models.Administration;

    public class ProductWebInputModel : IMapTo<ProductServiceInputModel>
    {
        [Required]
        [MaxLength(EntitiesAttributeConstraints.NameMaxLength)]
        public string Name { get; set; }

        public ProductType Type { get; set; }

        [Range(EntitiesAttributeConstraints.MinPrice, EntitiesAttributeConstraints.MaxPrice)]
        public double Price { get; set; }
    }
}
