using BlogStore.EntityLayer.Entities;
using BlogStore.PresentationLayer.Models;
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


        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> CreateUser(UserRegisterViewModel userRegisterViewModel)
        {
            AppUser appUser = new AppUser
            {
                Name = userRegisterViewModel.Name,
                Surname = userRegisterViewModel.Surname,
                UserName = userRegisterViewModel.Username,
                Email = userRegisterViewModel.Email,
                ImageUrl = "test", // Default image URL, can be changed later
                Description = "test" // Default description, can be changed later

            };
            await _userManager.CreateAsync(appUser, userRegisterViewModel.Password);
            return RedirectToAction("UserLogin", "Login");
        }
    }
}
