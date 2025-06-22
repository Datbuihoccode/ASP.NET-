using AutoMapper;
using MvcMovie.Models;
using MvcMovie.Applications.DTOs.Products;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductsDto>();
        CreateMap<CreateDto, Product>();
        CreateMap<UpdateDto, Product>();
    }
}
