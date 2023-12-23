using AutoMapper;
using Entities.Concrete;
using Entities.Concrete.Identity;
using Entities.Dtos.AddressDto;
using Entities.Dtos.CategoryDto;
using Entities.Dtos.CityDto;
using Entities.Dtos.ColorDto;
using Entities.Dtos.OrderDto;
using Entities.Dtos.ProductDto;
using Entities.Dtos.RoleDto;
using Entities.Dtos.UserDto;

namespace WebUI.Infrastructure.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<ProductDtoForInsertion, Product>().ReverseMap();
        CreateMap<ProductDtoForUpdate, Product>().ReverseMap();

        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<CategoryDtoForInsertion, Category>().ReverseMap();
        CreateMap<CategoryDtoForUpdate, Category>().ReverseMap();

        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<UserForLoginDto, User>().ReverseMap();
        CreateMap<UserForRegisterDto, User>().ReverseMap();
        CreateMap<UserForLoginDto, UserDto>().ReverseMap();

        CreateMap<RoleDto, Role>().ReverseMap();

        

        CreateMap<CityDto, City>().ReverseMap();
        CreateMap<CityDtoForInsertion, City>().ReverseMap();
        CreateMap<CityDtoForUpdate, City>().ReverseMap();

        CreateMap<AddressDto, Address>().ReverseMap();
        CreateMap<AddressDtoForUpdate, Address>().ReverseMap();
        CreateMap<AddressDtoForInsertion, Address>().ReverseMap();

        CreateMap<Color, ColorDto>().ReverseMap();

        CreateMap<OrderDto, Order>().ReverseMap();
    }
}