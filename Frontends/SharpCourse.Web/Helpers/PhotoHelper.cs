using System;
using Microsoft.Extensions.Options;
using SharpCourse.Web.Models;

namespace SharpCourse.Web.Helpers
{
	public class PhotoHelper
	{
		private readonly ServiceApiSettings _serviceApiSettings;

        public PhotoHelper(IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public string GetPhotoStockUrl(string photoUrl)
        {
            return $"{_serviceApiSettings.PhotoStockUrl}/photos/{photoUrl}";
        }
    }
}

