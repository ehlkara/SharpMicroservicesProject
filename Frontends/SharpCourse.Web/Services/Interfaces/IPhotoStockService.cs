using System;
using SharpCourse.Web.Models.PhotoStocks;

namespace SharpCourse.Web.Services.Interfaces
{
	public interface IPhotoStockService
	{
		Task<PhotoViewModel> UploadPhoto(IFormFile photo);
		Task<bool> DeletePhoto(string photoUrl);
	}
}

