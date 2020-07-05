namespace Frutify.Services.Models.Administration
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Fruitify.Common;
    using Fruitify.Data.Models;
    using Fruitify.Data.Models.Enums.Product;
    using Fruitify.Services.Mapping;
    using Frutify.Services.Models.Contracts;

    public class ProductServiceInputModel : IServiceInputModel, IMapTo<Product>
    {
        [Required]
        [MaxLength(EntitiesAttributeConstraints.NameMaxLength)]
        public string Name { get; set; }

        public ProductType Type { get; set; }

        [Range(EntitiesAttributeConstraints.MinPrice, EntitiesAttributeConstraints.MaxPrice)]
        public double Price { get; set; }
    }
}
