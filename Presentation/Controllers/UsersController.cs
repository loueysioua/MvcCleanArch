using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCleanArch.Infrastructure.Persistence.DbContext;
using MvcCleanArch.Domain.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MvcCleanArch.Application.DTOs.UserDtos;
using MvcCleanArch.Application.Services.ServiceContracts;

namespace MvcCleanArch.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAllUsersAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _userService.GetUserByIdAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {

            await _userService.CreateUserAsync(createUserDto);
            return RedirectToAction(nameof(Index));
        }



        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _userService.GetUserByIdAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UpdateUserDto updateUserDto)
        {

            await _userService.UpdateUserAsync(id, updateUserDto);
            return RedirectToAction(nameof(Index));


        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            var appUser = await _userService.GetUserByIdAsync(id);

            return View(appUser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _userService.DeleteUserAsync(id);
            return RedirectToAction(nameof(Index));
        }



    }

}