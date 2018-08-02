using AutoMapper;
using ProductShop.Import.Dtos;
using ProductShop.Models;

namespace ProductShop.Import
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();

        }
    }
}