﻿using AutoMapper;

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

            

        }
    }
}