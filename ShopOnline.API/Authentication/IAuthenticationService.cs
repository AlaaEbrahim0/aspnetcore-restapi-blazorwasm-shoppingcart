using ShopOnline.Models.Models;

namespace ShopOnline.API.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> RegisterUser(RegisterModel registerDto);
    }
}
