using System;
using SharpCourse.Web.Models.PhotoStocks;
using SharpCourse.Web.Services.Interfaces;

namespace SharpCourse.Web.Services
{
    public class PhotoStockService : IPhotoStockService
    {
        public Task<bool> DeletePhoto(string photoUrl)
        {
            throw new NotImplementedException();
        }

        public Task<PhotoViewModel> UploadPhoto(IFormFile photo)
        {
            throw new NotImplementedException();
        }
    }
}

