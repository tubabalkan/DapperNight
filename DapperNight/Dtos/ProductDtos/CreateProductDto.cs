﻿namespace DapperNight.Dtos.ProductDtos
{
    public class CreateProductDto
    {
       
        public string ProductName { get; set; }
        public int stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
