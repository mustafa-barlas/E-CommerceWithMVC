using Business.Abstract;
using Entities.Dtos.FilterDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public ReportController(IReportService reportService, IUserService userService, IRoleService roleService)
        {
            _reportService = reportService;
            _userService = userService;
            _roleService = roleService;
        }

        public IActionResult Index()
        {

            var result = _reportService.GetReportList();

            var userSelectList = new SelectList(_userService.GetByRoleId(), "Id", "FullName", "0");

            ViewBag.userSelectList = userSelectList;

            var roleSelectList = new SelectList(_roleService.FindAllWithAsNoTracking(false), "Id", "Name", "0");


            ViewBag.roleSelectList = roleSelectList;

            var viewModel = new HomeIndexViewModel()
            {
                ReportDtos = result,
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(FilterDto filter)
        {
            var result = _reportService.GetReportList(filter);

            return PartialView("_ReportPartial", result);
        }

    }
}
