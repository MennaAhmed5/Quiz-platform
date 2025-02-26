﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiz_platform.BL.ViewModels.Users;
using Quiz_platform.DAL.Data.Models;
using System.Security.Claims;

namespace Quiz_platform.Controllers
{
    public class UsersController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManger = userManager;
            _signInManager = signInManager;
        }

        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }
            var user = new ApplicationUser()
            {
                UserName = registerVM.UserName,
                Email = registerVM.Email,
            };
            var result = await _userManger.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(registerVM);
                }
            }

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id),
                new (ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, "Admin")

            };

            await _userManger.AddClaimsAsync(user, claims);

            return RedirectToAction("Login", "Users");
        }




        #endregion

        #region Login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }
            var user = await _userManger.FindByEmailAsync(loginVM.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View();
            }
            var isAuthenticated = await _userManger.CheckPasswordAsync(user, loginVM.Password);
            if (!isAuthenticated)
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View();
            }

            //set token in the cookie
            var claims = await _userManger.GetClaimsAsync(user);

            //set the token in the cookies

            await _signInManager.SignInWithClaimsAsync(user, true, claims);
            return RedirectToAction("Index", "Quizzes");
        }


       #endregion

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
