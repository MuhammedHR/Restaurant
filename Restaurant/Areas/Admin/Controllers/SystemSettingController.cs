using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using Restaurant.ViewModels;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Authorize]

    [Area("Admin")]
    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> SystemSetting { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public SystemSettingController(IRepository<SystemSetting> _SystemSetting,
       Microsoft.AspNetCore.Hosting.IHostingEnvironment _Host)
        {
            SystemSetting = _SystemSetting;
            Host = _Host;
        }
        public ActionResult Search(string strName)
        {
            SystemSettingModel obj = new SystemSettingModel();

            if (strName == null)
            {

                return RedirectToAction(nameof(Index));
            }
            var data = SystemSetting.Search(strName);
            if (data.Count <= 0)
            {

                return RedirectToAction(nameof(Index));
            }
            obj.ListSystemSetting = data;

            return View(viewName: "Index", obj);



        }

        // GET: SystemSettingController
        public ActionResult Index(int idDelete)
        {

            SystemSettingModel obj = new SystemSettingModel();
            if (idDelete != 0)
            {
                SystemSetting data = new SystemSetting()
                {
                    EditDate = DateTime.UtcNow,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreateDate = obj.CreateDate,
                    CreateUser = obj.CreateUser,
                    IsDelete = false
                };

                SystemSetting.Delete(idDelete, data);
                return RedirectToAction(nameof(Index));


            }
            obj.ListSystemSetting = SystemSetting.view().ToList();

            return View(obj);
        }

   

        // GET: SystemSettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemSettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemSettingModel collection)
        {
            try
            {
                string ImageName = UploadImage(collection.File);
                string ImageName2 = UploadImage2(collection.File2);
                string ImageName3 = UploadImage(collection.File3);


                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please Enter The Reqierd Field");

                    return View();

                }
                SystemSetting data = new SystemSetting
                {
                    SystemSettingId = collection.SystemSettingId,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingMapLocation = collection.SystemSettingMapLocation,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingLogoImageUrl = ImageName,
                    SystemSettingLogoImageUrl2 = ImageName2,
                    SystemSettingWelcomeNoteImageUrl = ImageName3,
                    SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl,
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,

                };

                SystemSetting.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = SystemSetting.find(id);

            var Res = new SystemSettingModel
            {
                SystemSettingId = data.SystemSettingId,
                SystemSettingCopyright = data.SystemSettingCopyright,
                SystemSettingMapLocation = data.SystemSettingMapLocation,
                SystemSettingWelcomeNoteBreef = data.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc = data.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle,
                SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl,
                SystemSettingLogoImageUrl2 = data.SystemSettingLogoImageUrl2,
                SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl,
                SystemSettingWelcomeNoteUrl = data.SystemSettingWelcomeNoteUrl,
                CreateDate = data.CreateDate,
                CreateUser = data.CreateUser,
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                IsActive = data.IsActive,
                IsDelete = data.IsDelete,


            };
            return View(Res); ;
        }

        // POST: SystemSettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SystemSettingModel collection)
        {
            try
            {
                string ImageName = UploadImage(collection.File);
                string ImageName2 = UploadImage2(collection.File2);
                string ImageName3 = UploadImage(collection.File3);
                string ImageName4 = UploadImage2(collection.File4);

                var data = new SystemSetting
                {
                    SystemSettingId = collection.SystemSettingId,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingMapLocation = collection.SystemSettingMapLocation,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingLogoImageUrl = (ImageName != "") ? ImageName : collection.SystemSettingLogoImageUrl,
                    SystemSettingLogoImageUrl2 = (ImageName2 != "") ? ImageName2 : collection.SystemSettingLogoImageUrl2,
                    SystemSettingWelcomeNoteImageUrl = (ImageName3 != "") ? ImageName3 : collection.SystemSettingWelcomeNoteImageUrl,
                    SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl,
                    CreateDate = collection.CreateDate,
                    CreateUser = collection.CreateUser,
                    EditDate = DateTime.Now,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = collection.IsActive,
                    IsDelete = collection.IsDelete,


                };
                SystemSetting.Update(id, data);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Active(int id)
        {
            SystemSetting.Active(id, new SystemSetting()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
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
        String UploadImage2(IFormFile File)
        {

            String ImageName2 = "";
            if (File != null)

            {
                string pathImage = Path.Combine(Host.WebRootPath, "ImageApp");
                FileInfo fa = new FileInfo(File.FileName);

                ImageName2 = "Image_" + Guid.NewGuid() + fa.Extension;

                string FullPath = Path.Combine(pathImage, ImageName2);
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }


            return ImageName2;
        }
        String UploadImage3(IFormFile File)
        {

            String ImageName3 = "";
            if (File != null)

            {
                string pathImage = Path.Combine(Host.WebRootPath, "ImageApp");
                FileInfo fa = new FileInfo(File.FileName);

                ImageName3 = "Image_" + Guid.NewGuid() + fa.Extension;

                string FullPath = Path.Combine(pathImage, ImageName3);
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }


            return ImageName3;
        }
      
    }
}
