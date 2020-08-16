namespace Fruitify.Data.Models.Enums.Receipt
{
    using System.ComponentModel.DataAnnotations;

    public enum ReceiptType
    {
        [Display(Name = "Сок")]
        Juice = 1,

        [Display(Name = "Салата")]
        Salad = 2,
    }
}
