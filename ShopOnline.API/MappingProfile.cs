using AutoMapper;
using ShopOnline.Models.Models;

namespace ShopOnline.API
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, src => src.MapFrom(p => p.Category.Name));

            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.ProductName, src => src.MapFrom(c => c.Product.Name))
                .ForMember(dest => dest.ProductDescription, src => src.MapFrom(c => c.Product.Description))
                .ForMember(dest => dest.ProductImageURL, src => src.MapFrom(c => c.Product.ImageUrl))
                .ForMember(dest => dest.Price, src => src.MapFrom(c => c.Product.Price))
                .ForMember(dest => dest.TotalPrice, src => src.MapFrom(c => c.Product.Price * c.Qty));

            CreateMap<RegisterModel, AppUser>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(u => u.Email.Split("@", StringSplitOptions.None)[0]));

        }
    }
}
