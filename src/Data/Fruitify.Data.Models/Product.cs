namespace Fruitify.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Fruitify.Common;
    using Fruitify.Data.Common.Models;
    using Fruitify.Data.Models.Enums.Product;

    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;

            this.DayProduct = false;
            this.WeekProduct = false;
        }

        [Required]
        [MaxLength(EntitiesAttributeConstraints.NameMaxLength)]
        public string Name { get; set; }

        public ProductType Type { get; set; }

        [Range(EntitiesAttributeConstraints.MinPrice, EntitiesAttributeConstraints.MaxPrice)]
        public double Price { get; set; }

        [Required]
        [MaxLength(EntitiesAttributeConstraints.UrlMaxLength)]
        public string Image { get; set; }

        [Range(EntitiesAttributeConstraints.MinPrice, EntitiesAttributeConstraints.MaxPrice)]
        public double PromoPrice { get; set; }

        public bool DayProduct { get; set; }

        public bool WeekProduct { get; set; }
    }
}
