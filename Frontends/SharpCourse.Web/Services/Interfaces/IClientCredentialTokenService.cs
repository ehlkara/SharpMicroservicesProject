using System;
namespace SharpCourse.Web.Services.Interfaces
{
	public interface IClientCredentialTokenService
	{
        Task<String> GetToken();
    }
}

