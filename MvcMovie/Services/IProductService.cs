using MvcMovie.Models;
using MvcMovie.Applications.DTOs.Products;

//tạo Interface cho Service
public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> CreateAsync(CreateDto dto);
    Task<bool> UpdateAsync(UpdateDto dto);
    Task<bool> DeleteAsync(int id);
}