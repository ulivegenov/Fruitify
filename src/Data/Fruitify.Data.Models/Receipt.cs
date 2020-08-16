namespace Fruitify.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Fruitify.Common;
    using Fruitify.Data.Common.Models;
    using Fruitify.Data.Models.Enums.Receipt;

    public class Receipt : BaseDeletableModel<int>
    {
        public Receipt()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
        }

        [Required]
        [MaxLength(EntitiesAttributeConstraints.NameMaxLength)]
        public string Name { get; set; }

        public ReceiptType Type { get; set; }

        [Required]
        [Range(EntitiesAttributeConstraints.DescriptionMinLength, EntitiesAttributeConstraints.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(EntitiesAttributeConstraints.UrlMaxLength)]
        public string Image { get; set; }
    }
}
