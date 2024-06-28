﻿using Dapper;
using DapperNight.Context;
using DapperNight.Dtos.CategoryDtos;

namespace DapperNight.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly DapperContext _context;

        public CategoryService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "insert into TblCategory(CategoryName) values(@categoryName)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", createCategoryDto.CategoryName);
            var connection =_context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            string query = "Delete From TblCategory Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From TblCategory";
            var connection = _context.CreateConnection();
            var values= await connection.QueryAsync<ResultCategoryDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id)
        {
            string query = "select * from TblCategory Where CategoryId=@categoryId";
            var parameters= new DynamicParameters();
            parameters.Add("@categoryId", id);
            var x = _context.CreateConnection();
            var values=await x.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query,parameters);
            return values;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            string query = "update TblCategory Set CategoryName=@categoryName where CategoryId=@categoryId";
            var parametrs= new DynamicParameters();
            parametrs.Add("@categoryName", updateCategoryDto.CategoryName);
            parametrs.Add("@categoryId", updateCategoryDto.CategoryId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query,parametrs);

        }
    }
}
