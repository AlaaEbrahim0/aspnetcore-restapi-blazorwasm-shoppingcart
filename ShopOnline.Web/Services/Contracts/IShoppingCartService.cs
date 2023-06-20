using ShopOnline.Models.Dtos;

namespace ShopOnline.Web.Services.Contracts
{
    public interface IShoppingCartService
    {
        Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAdd);
        Task<CartItemDto> GetItem(int itemId);
        Task<IEnumerable<CartItemDto>> GetAll(int userId);
    }
}
