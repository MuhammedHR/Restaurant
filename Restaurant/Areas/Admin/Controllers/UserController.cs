﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModels;
using Restaurant.Models;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Authorize]

    [Area("Admin")]
    public class UserController : Controller
    {
        public UserManager<AppUser> UserManager { get; }

        public UserController(UserManager<AppUser> userManager)
        {
            UserManager = userManager;
        }


        public IActionResult Index()
        {
            IList<AppUser> dataList = UserManager.Users.Where(data => !data.IsDelete).ToList(); // && data.Id != User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            return View(dataList);
        }

        // GET: UserController/Details/5
        public async Task<IActionResult> Active(string id)
        {
            AppUser data = UserManager.Users.SingleOrDefault(data => data.Id == id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.UtcNow;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await UserManager.UpdateAsync(data);
            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Create
        public IActionResult Create()
        {
            Register dataViewModel = new Register();
            return View(dataViewModel);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Register dataViewModel)
        {
            try
            {
                AppUser user = new AppUser()
                {
                    Email = dataViewModel.Emial,
                    UserName = dataViewModel.UserName,
                    IsActive = true,
                    IsDelete = false,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
                //if (!ModelState.IsValid)
                //{
                //    if (string.IsNullOrEmpty(dataViewModel.Emial))
                //    {
                //        ModelState.AddModelError("", "Please Enter The Email");
                //    }
                //    if (string.IsNullOrEmpty(dataViewModel.Password) || string.IsNullOrEmpty(dataViewModel.ConfirmPassword))
                //    {
                //        ModelState.AddModelError("", "Please Enter The Password And Confirm It");
                //    }
                //    return View(dataViewModel);
                //}
                var userExist = UserManager.Users.SingleOrDefault(u => u.UserName.ToUpper() == user.UserName.ToUpper());


                if (userExist != null && !string.IsNullOrEmpty(userExist.UserName))
                {
                    ModelState.AddModelError("", "This user is already exist");
                }

                if (userExist == null)
                {
                    var Result = await UserManager.CreateAsync(user, dataViewModel.Password);
                    if (Result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

                return View(dataViewModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public IActionResult Edit(string id)
        {
            AppUser data = UserManager.Users.SingleOrDefault(data => data.Id == id);
            return View(data);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, AppUser data)
        {
            try
            {
                if (UserManager.Users.SingleOrDefault(dataU => dataU.Email.ToUpper() == data.Email.ToUpper() && dataU.Id != data.Id) != null)
                {
                    ModelState.AddModelError("", "This email is already exist");
                    return View(data);
                }
                AppUser appUser = await UserManager.FindByIdAsync(data.Id);
                appUser.Email = data.Email;
                appUser.UserName = data.UserName;
                appUser.EditDate = DateTime.UtcNow;
                appUser.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var r = await UserManager.UpdateAsync(appUser);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            AppUser data = UserManager.Users.SingleOrDefault(data => data.Id == id);
            data.IsDelete = true;
            data.EditDate = DateTime.UtcNow;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await UserManager.UpdateAsync(data);
            return RedirectToAction(nameof(Index));
        }

    }
}
