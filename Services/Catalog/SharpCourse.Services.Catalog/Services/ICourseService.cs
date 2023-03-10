using System;
using Sharp.Shared.Dtos;
using SharpCourse.Services.Catalog.Dtos;

namespace SharpCourse.Services.Catalog.Services
{
	public interface ICourseService
	{
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<CourseDto>> GetByIdAsync(string Id);
        Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId);
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto);
        Task<Response<NoContent>> DeleteAsync(string Id);
    }
}

