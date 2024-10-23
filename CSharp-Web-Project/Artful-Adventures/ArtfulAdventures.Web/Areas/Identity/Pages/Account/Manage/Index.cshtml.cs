// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using ArtfulAdventures.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using static ArtfulAdventures.Common.DataModelsValidationConstants.ApplicationUserConstants;

namespace ArtfulAdventures.Web.Areas.Identity.Pages.Account.Manage
{
	public class IndexModel : PageModel
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public IndexModel(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public string Username { get; set; } = null!;

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		[TempData]
		public string StatusMessage { get; set; } = null!;

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		[BindProperty]
		public InputModel Input { get; set; } = null!;

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public class InputModel
		{
			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
			[Display(Name = "Name")]
			public string? Name { get; set; }

			[EmailAddress]
			[Display(Name = "Email")]
			public string? Email { get; set; }

			[Phone]
			[Display(Name = "Phone number")]
			public string? PhoneNumber { get; set; }

			[StringLength(CityNameMaxLength, MinimumLength = CityNameMinLength)]
			[Display(Name = "City")]
			public string? City { get; set; }

			[StringLength(BioMaxLength, MinimumLength = BioMinLength)]
			[Display(Name = "Bio")]
			public string? Bio { get; set; }

			[StringLength(AboutMaxLength, MinimumLength = AboutMinLength)]
			[Display(Name = "About")]
			public string? About { get; set; }

			public string? ProfilePictureUrl { get; set; }
		}

		private async Task LoadAsync(ApplicationUser user)
		{
			var userName = await _userManager.GetUserNameAsync(user);
			//var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

			Username = userName;

			Input = new InputModel
			{
				Name = user.Name,
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				City = user.CityName,
				Bio = user.Bio,
				About = user.About,
				ProfilePictureUrl = Path.GetFileName(user.Url)
			};
		}

		public async Task<IActionResult> OnGetAsync()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
			}

			await LoadAsync(user);
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
			}

			if (!ModelState.IsValid)
			{
				await LoadAsync(user);
				return Page();
			}
			var name = user.Name;
			if (Input.Name != name)
			{
				user.Name = Input.Name;
				var result = await _userManager.UpdateAsync(user);
				if (!result.Succeeded)
				{
					StatusMessage = "Unexpected error when trying to update name.";
					return RedirectToPage();
				}
			}

			var email = user.Email;
			if (Input.Email != email)
			{
				var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
				if (!setEmailResult.Succeeded)
				{
					StatusMessage = "Unexpected error when trying to set email.";
					return RedirectToPage();
				}

			}

			var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
			if (Input.PhoneNumber != phoneNumber)
			{
				var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
				if (!setPhoneResult.Succeeded)
				{
					StatusMessage = "Unexpected error when trying to set phone number.";
					return RedirectToPage();
				}
			}
			
			var city = user.CityName;
			if (Input.City != city)
			{
				user.CityName = Input.City;
				var result = await _userManager.UpdateAsync(user);
				if (!result.Succeeded)
				{
					StatusMessage = "Unexpected error when trying to update city.";
					return RedirectToPage();
				}
			}

			var bio = user.Bio;
			if (Input.Bio != bio)
			{
				user.Bio = Input.Bio;
				var result = await _userManager.UpdateAsync(user);
				if (!result.Succeeded)
				{
					StatusMessage = "Unexpected error when trying to update bio.";
					return RedirectToPage();
				}
			}

			var about = user.About;
			if (Input.About != about)
			{
				user.About = Input.About;
				var result = await _userManager.UpdateAsync(user);
				if (!result.Succeeded)
				{
					StatusMessage = "Unexpected error when trying to update about.";
					return RedirectToPage();
				}
			}
			await _signInManager.RefreshSignInAsync(user);
			StatusMessage = "Your profile has been updated";
			return RedirectToPage();
		}
	}
}
