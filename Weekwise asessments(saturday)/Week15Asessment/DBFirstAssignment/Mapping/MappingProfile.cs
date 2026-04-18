using AutoMapper;
using NorthwindAPI.DTOs;
using NorthwindAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NorthwindAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.ImageUrl,
                    opt => opt.MapFrom(src => "/images/" + src.CategoryId + ".jpeg"));

            CreateMap<Product, ProductDto>();
        }
    }
}