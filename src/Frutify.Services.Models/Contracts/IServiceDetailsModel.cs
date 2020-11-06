namespace Fruitify.Services.Models.Contracts
{
    using Fruitify.Data.Models.Enums.Product;

    public interface IServiceDetailsModel<TKey>
    {
        public TKey Id { get; set; }

        string Name { get; set; }

        string Image { get; set; }
    }
}
