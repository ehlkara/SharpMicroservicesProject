using System;
using SharpCourse.Web.Models;

namespace SharpCourse.Web.Services.Interfaces
{
	public interface IUserService
	{
		Task<UserViewModel> GetUser(); 
	}
}

