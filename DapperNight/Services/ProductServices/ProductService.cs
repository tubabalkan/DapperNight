using Dapper;
using DapperNight.Context;
using DapperNight.Dtos.CategoryDtos;
using DapperNight.Dtos.ProductDtos;

namespace DapperNight.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly DapperContext _context;

        public ProductService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            string query = "insert into TblProduct(ProductName,stock,Price,CategoryId) values (@productName,@stock,@price,@categoryId)";
            var parameters = new DynamicParameters();
            parameters.Add("@productName", createProductDto.ProductName);
            parameters.Add("@stock", createProductDto.stock);
            parameters.Add("@price", createProductDto.Price);
            parameters.Add("@categoryId", createProductDto.CategoryId);
            var connection=_context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);

        }

        public async Task DeleteProductAsync(int id)
        {
            string query = "Delete From TblProduct Where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From TblProduct";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultProductDto>(query);
            return values.ToList();
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "SELECT dbo.TblProduct.ProductId, dbo.TblProduct.ProductName, dbo.TblProduct.Stock, dbo.TblProduct.Price, dbo.TblCategory.CategoryName FROM  dbo.TblCategory INNER JOIN dbo.TblProduct ON dbo.TblCategory.CategoryId = dbo.TblProduct.CategoryId";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
            return values.ToList();
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithProcCategoryAsync()
        {
            string query = "ExecuteProductList";
            var parameters = new DynamicParameters();
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query, parameters);
           
            return values.ToList();
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(int id)
        {
            string query = "select * from TblProduct Where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            var x = _context.CreateConnection();
            var values = await x.QueryFirstOrDefaultAsync<GetByIdProductDto>(query, parameters);
            return values;
        }

        public async Task<int> GetProductCountAsync()
        {
            string query = "Select Count(*) From TblProduct";
            var connection = _context.CreateConnection();
            int productCount= await connection.QueryFirstAsync<int>(query);
            return productCount;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            string query = "update TblProduct Set ProductName=@productName, Stock=@stock, Price=@price, CategoryId=@categoryId where ProductId=@productId";
            var parametrs = new DynamicParameters();
            parametrs.Add("@productName", updateProductDto.ProductName);
            parametrs.Add("@stock", updateProductDto.stock);
            parametrs.Add("@price", updateProductDto.Price);
            parametrs.Add("@categoryId", updateProductDto.CategoryId);
            parametrs.Add("@productId", updateProductDto.ProductId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parametrs);
            

        }
    }
}
