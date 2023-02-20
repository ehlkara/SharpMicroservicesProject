using System;
using SharpCourse.Web.Models.Catalogs;

namespace SharpCourse.Web.Services.Interfaces
{
	public interface ICatalogService
	{
		Task<List<CourseViewModel>> GetAllCourseAsync();

		Task<List<CategoryViewModel>> GetAllCategoryAsync();

		Task<List<CourseViewModel>> GetAllCourseByUserIdAsync(string userId);

		Task<CourseViewModel> GetByCourseIdAsync(string courseId);

		Task<bool> CreateCourseAsync(CourseCreateInput courseCreateInput);

		Task<bool> UpdateCourseAsync(CourseUpdateInput courseUpdateInput);

        Task<bool> DeleteCourseAsync(string courseId);
    }
}

