using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult GetUserByRole(int roleId)
        {
            var users = _userService.GetByRoleId(roleId);
            return Json(users);
        }
    }
}
