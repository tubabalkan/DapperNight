using DapperNight.Dtos.CategoryDtos;
using DapperNight.Dtos.ProductDtos;

namespace DapperNight.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
      
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithProcCategoryAsync();
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(int id);
        Task<GetByIdProductDto> GetByIdProductAsync(int id);
        Task<int> GetProductCountAsync();
    }
}
