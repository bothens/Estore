Application_Layer\Common\Mappers\AutoMapper.cs
using AutoMapper;
using Application_Layer.Dtos.ProductDtos;
using Domain_Layer.Models;

namespace Application_Layer.Common.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, ProductResponseDto>();
            CreateMap<CreateProductDto, ProductResponseDto>().ConvertUsing((src, dest, ctx) => ctx.Mapper.Map<ProductResponseDto>(ctx.Mapper.Map<Product>(src)));
        }
    }
}