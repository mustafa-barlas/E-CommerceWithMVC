using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Dtos.UserDto;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IValidator<UserForRegisterDto> _validator;

        public UserController(IAccountService accountService, IValidator<UserForRegisterDto> validator)
        {
            _accountService = accountService;
            _validator = validator;
        }


        public IActionResult Login(string returnUrl)
        {
            UserForLoginDto userForLogin = new UserForLoginDto()
            {
                ReturnUrl = returnUrl
            };

            return View(userForLogin);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserForLoginDto forLoginDto)
        {
            if (ModelState.IsValid)
            {

                UserDto user = new UserDto();
                Result result = _accountService.Login(forLoginDto, user);


                if (result.Success)
                {
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Email, user.Email),

                        new Claim(ClaimTypes.Role, user.Role.Name),

                        new Claim(ClaimTypes.Sid, user.UserId.ToString()),

                        new Claim(ClaimTypes.Name, user.FirstName),

                        new Claim(ClaimTypes.Surname, user.LastName),
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();

                    if (!string.IsNullOrWhiteSpace(forLoginDto.ReturnUrl))
                        return Redirect(forLoginDto.ReturnUrl);

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    ModelState.AddModelError("", Messages.UserNotFound);
                }

            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult AccessDenied()
        {
            return View("_Error", "Access is denied for this page!");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserForRegisterDto userForRegister)
        {

            var validationResult = _validator.Validate(userForRegister);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(userForRegister);
            }
            else
            {
                Result result = _accountService.Register(userForRegister);

                if (result.Success)
                {

                    return RedirectToAction("Login");
                }
            }

            return View();
        }

    }
}
