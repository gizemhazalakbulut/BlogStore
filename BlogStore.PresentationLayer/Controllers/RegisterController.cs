using BlogStore.EntityLayer.Entities;
using BlogStore.PresentationLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace BlogStore.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> CreateUser(UserRegisterViewModel userRegisterViewModel)
        {
            if (!ModelState.IsValid) return View(userRegisterViewModel);

            AppUser appUser = new AppUser
            {
                Name = userRegisterViewModel.Name,
                Surname = userRegisterViewModel.Surname,
                UserName = userRegisterViewModel.Username,
                Email = userRegisterViewModel.Email,
                ImageUrl = "test", // Default image URL, can be changed later
                Description = "test" // Default description, can be changed later

            };
           var result = await _userManager.CreateAsync(appUser, userRegisterViewModel.Password);
            if (result.Succeeded)
            {
                // İstersen otomatik giriş yap:
                // await _signInManager.SignInAsync(appUser, isPersistent: true);
                return RedirectToAction("UserLogin", "Login");
            }

            foreach (var e in result.Errors)
                ModelState.AddModelError(string.Empty, e.Description);

            return View(userRegisterViewModel);
        }
    }
}
