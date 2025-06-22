// Services/ProductService.cs
using MvcMovie.Data;
using MvcMovie.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MvcMovie.Applications.DTOs.Products;


public class ProductService : IProductService
{
    private readonly IProductRepository _productRepo;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepo, IMapper mapper)
    {
        _productRepo = productRepo;
        _mapper = mapper;
    }

    public virtual async Task<IEnumerable<Product>> GetAllAsync()// thông tin toàn bộ sản phẩm
    {
        var products = await _productRepo.GetAllAsync();
        return _mapper.Map<IEnumerable<Product>>(products);
    }

    public virtual async Task<Product?> GetByIdAsync(int id)// Tìm kiếm sản phẩm theo id
    {
        var product = await _productRepo.GetByIdAsync(id);
        return product == null ? null : _mapper.Map<Product>(product);
    }

    public virtual async Task<Product> CreateAsync(CreateDto dto)// Tạo sản phẩm mới 
    {
        // Logic đơn giản: không cho tên rỗng 
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException("Tên sản phẩm không được để trống");
        }
        var product = _mapper.Map<Product>(dto);
        var created = await _productRepo.CreateAsync(product);
        return _mapper.Map<Product>(created);
    }

    public virtual async Task<bool> UpdateAsync( UpdateDto dto)// Cập nhật sản phẩm
    {
        // Logic đơn giản: không cho giá âm
        if (dto.Price < 0) return false;

        var product = _mapper.Map<Product>(dto);
        return await _productRepo.UpdateAsync(product);
    }


    public virtual async Task<bool> DeleteAsync(int id)// Xóa sản phẩm
    {
        var product = await _productRepo.GetByIdAsync(id);
        if (product == null) return false;

        return await _productRepo.DeleteAsync(id);
    }
}
