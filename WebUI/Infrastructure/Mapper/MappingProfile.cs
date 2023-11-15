using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.CategoryDto;
using Entities.Dtos.ProductDto;

namespace WebUI.Infrastructure.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDtoForInsertion, Product>().ReverseMap();
        CreateMap<ProductDtoForUpdate, Product>().ReverseMap();

        CreateMap<CategoryDtoForInsertion, Category>().ReverseMap();
        CreateMap<CategoryDtoForUpdate, Category>().ReverseMap();
        
    }
}