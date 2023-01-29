using System;
using Sharp.Shared.Dtos;
using SharpCourse.Services.Catalog.Dtos;
using SharpCourse.Services.Catalog.Models;

namespace SharpCourse.Services.Catalog.Services
{
	public interface ICategoryService
	{
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<Response<CategoryDto>> GetByIdAsync(string Id);
    }
}

