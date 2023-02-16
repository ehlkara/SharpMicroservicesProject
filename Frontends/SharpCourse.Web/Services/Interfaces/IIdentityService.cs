using System;
using IdentityModel.Client;
using Sharp.Shared.Dtos;
using SharpCourse.Web.Models;

namespace SharpCourse.Web.Services.Interfaces
{
	public interface IIdentityService
	{
		Task<Response<bool>> SignIn(SigninInput signinInput);

		Task<TokenResponse> GetAccessTokenByRefreshToken();

		Task RevokeRefreshToken();
	}
}

