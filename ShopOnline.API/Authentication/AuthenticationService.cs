using ShopOnline.Models.Models;

namespace ShopOnline.API.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AppDbContext dbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public AuthenticationService(AppDbContext dbContext, UserManager<AppUser> userManager, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<bool> RegisterUser(RegisterModel registerDto)
        {
            var user = mapper.Map<AppUser>(registerDto);
            var result = await userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }
    }
}
