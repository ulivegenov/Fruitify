using Fruitify.Data.Models.Enums.Product;

namespace Frutify.Services.Models.Contracts
{
    public interface IServiceDetailsModel<TKey>
    {
        public TKey Id { get; set; }

        string Name { get; set; }

        string Image { get; set; }
    }
}
