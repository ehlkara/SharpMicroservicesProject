using System;
using SharpCourse.Web.Models.PhotoStocks;
using SharpCourse.Web.Services.Interfaces;

namespace SharpCourse.Web.Services
{
    public class PhotoStockService : IPhotoStockService
    {
        private readonly HttpClient _httClient;

        public PhotoStockService(HttpClient httClient)
        {
            _httClient = httClient;
        }

        public async Task<bool> DeletePhoto(string photoUrl)
        {
            var response = await _httClient.DeleteAsync($"photos?photoUrl={photoUrl}");
            return response.IsSuccessStatusCode;
        }

        public async Task<PhotoViewModel> UploadPhoto(IFormFile photo)
        {
            if(photo == null || photo.Length <= 0)
            {
                return null;
            }

            // example fileName = 26253726652.jpg
            var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(photo.FileName)}";

            using var ms = new MemoryStream();

            await photo.CopyToAsync(ms);

            var multipartContent = new MultipartFormDataContent();

            multipartContent.Add(new ByteArrayContent(ms.ToArray()), "photo", randomFileName);

            var response = await _httClient.PostAsync("photos", multipartContent);

            if(!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<PhotoViewModel>();
        }
    }
}

