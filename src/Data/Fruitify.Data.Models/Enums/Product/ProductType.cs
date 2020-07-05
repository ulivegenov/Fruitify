namespace Fruitify.Data.Models.Enums.Product
{
    using System.ComponentModel.DataAnnotations;

    public enum ProductType
    {
        [Display(Name = "Плод")]
        Fruit = 1,

        [Display(Name = "Зеленчук")]
        Vegetable = 2,
    }
}
