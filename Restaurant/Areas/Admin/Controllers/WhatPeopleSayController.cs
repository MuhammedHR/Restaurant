using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using Restaurant.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.Areas.Admin.Controllers
{
    [Authorize]

    [Area("Admin")]
    public class WhatPeopleSayController : Controller
    {
        public IRepository<WhatPeopleSay> WhatPeopleSay { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public WhatPeopleSayController(IRepository<WhatPeopleSay> _WhatPeopleSay ,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment _Host)
        {
            WhatPeopleSay = _WhatPeopleSay;
            Host = _Host;
        }

        // GET: WhatPeopleSayController
        public ActionResult Index(int idDelete)
        {

            WhatPeopleSayModel obj = new WhatPeopleSayModel();
            if (idDelete != 0)
            {
                WhatPeopleSay data = new WhatPeopleSay()
                {
                    EditDate = DateTime.UtcNow,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreateDate = obj.CreateDate,
                    CreateUser = obj.CreateUser,
                    IsDelete = false
                };

                WhatPeopleSay.Delete(idDelete, data);
                return RedirectToAction(nameof(Index));


            }
            obj.ListWhatPeopleSay = WhatPeopleSay.view().ToList();

            return View(obj);
        }
        public ActionResult Active(int id)
        {
            WhatPeopleSay.Active(id, new WhatPeopleSay()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        // GET: WhatPeopleSayController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WhatPeopleSayController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WhatPeopleSayModel collection)
        {
            try
            {
                string ImageName = UploadImage(collection.File);

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please Enter The Reqierd Field");

                    return View();

                }
                WhatPeopleSay data = new WhatPeopleSay
                {
                    WhatPeopleSayId = collection.WhatPeopleSayId,
                    WhatPeopleSayName = collection.WhatPeopleSayName,
                    WhatPeopleSayDescription = collection.WhatPeopleSayDescription,
                    WhatPeopleSayImage = ImageName,
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,

                };

                WhatPeopleSay.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WhatPeopleSayController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = WhatPeopleSay.find(id);

            var Res = new WhatPeopleSayModel
            {
                WhatPeopleSayId = data.WhatPeopleSayId,
                WhatPeopleSayName = data.WhatPeopleSayName,
                WhatPeopleSayDescription = data.WhatPeopleSayDescription,
                WhatPeopleSayImage = data.WhatPeopleSayImage,
                CreateDate = data.CreateDate,
                CreateUser = data.CreateUser,
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                IsActive = data.IsActive,
                IsDelete = data.IsDelete,


            };
            return View(Res);
        }

        // POST: WhatPeopleSayController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WhatPeopleSayModel collection)
        {
            try
            {
                string ImageName = UploadImage(collection.File);
                var data = new WhatPeopleSay
                {
                    WhatPeopleSayId = collection.WhatPeopleSayId,
                    WhatPeopleSayName = collection.WhatPeopleSayName,
                    WhatPeopleSayDescription = collection.WhatPeopleSayDescription,
                    WhatPeopleSayImage = (ImageName != "") ? ImageName : collection.WhatPeopleSayImage,
                    CreateDate = collection.CreateDate,
                    CreateUser = collection.CreateUser,
                    EditDate = DateTime.Now,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = collection.IsActive,
                    IsDelete = collection.IsDelete,


                };
                WhatPeopleSay.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        String UploadImage(IFormFile File)
        {

            String ImageName = "";
            if (File != null)

            {
                string pathImage = Path.Combine(Host.WebRootPath, "ImageApp");
                FileInfo fa = new FileInfo(File.FileName);

                ImageName = "Image_" + Guid.NewGuid() + fa.Extension;

                string FullPath = Path.Combine(pathImage, ImageName);
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }


            return ImageName;
        }
    }
}
