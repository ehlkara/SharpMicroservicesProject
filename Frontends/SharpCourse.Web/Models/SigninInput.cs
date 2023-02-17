using System;
using System.ComponentModel.DataAnnotations;

namespace SharpCourse.Web.Models
{
	public class SigninInput
	{
		[Required]
		[Display(Name = "Email Address")]
		public string Email { get; set; }
		[Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
		[Required]
        [Display(Name = "Remember Me")]
        public bool IsRemember { get; set; }
	}
}

