using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using Microsoft.AspNetCore.Authorization;
using Restaurant.ViewModels;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Authorize]

    [Area("Admin")]
    public class MasterSocialMediumController : Controller
    {
        public IRepository<MasterSocialMedium> MasterSocialMedium { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterSocialMediumController(IRepository<MasterSocialMedium> _MasterSocialMedium,
               Microsoft.AspNetCore.Hosting.IHostingEnvironment _Host)
        {
            MasterSocialMedium = _MasterSocialMedium;
            Host = _Host;
        }
        public ActionResult Search(string strName)
        {
            MasterSocialMediumModel obj = new MasterSocialMediumModel();

            if (strName == null)
            {

                return RedirectToAction(nameof(Index));
            }
            var data = MasterSocialMedium.Search(strName);
            if (data.Count <= 0)
            {

                return RedirectToAction(nameof(Index));
            }
            obj.ListMasterSocialMedium = data;

            return View(viewName: "Index", obj);



        }
        // GET: MasterSocialMediumController
        public ActionResult Index(int idDelete)
        {

            MasterSocialMediumModel obj = new MasterSocialMediumModel();
            if (idDelete != 0)
            {
                MasterSocialMedium data = new MasterSocialMedium()
                {
                    EditDate = DateTime.UtcNow,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreateDate = obj.CreateDate,
                    CreateUser = obj.CreateUser,
                    IsDelete = false
                };

                MasterSocialMedium.Delete(idDelete, data);
                return RedirectToAction(nameof(Index));


            }
            obj.ListMasterSocialMedium = MasterSocialMedium.view().ToList();

            return View(obj);
        }




        // GET: MasterSocialMediumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSocialMediumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSocialMediumModel collection)
        {
            try
            {
                string ImageName = UploadImage(collection.File);


                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please Enter The Reqierd Field");

                    return View();

                }
                MasterSocialMedium data = new MasterSocialMedium
                {
                    MasterSocialMediumId = collection.MasterSocialMediumId,
                    MasterSocialMediaIcon = ImageName,
                    MasterSocialMediaUrl = collection.MasterSocialMediaUrl,
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,

                };

                MasterSocialMedium.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Active(int id)
        {
            MasterSocialMedium.Active(id, new MasterSocialMedium()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterSocialMediumController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSocialMedium.find(id);

            var Res = new MasterSocialMediumModel
            {
                MasterSocialMediumId = data.MasterSocialMediumId,
                MasterSocialMediaIcon = data.MasterSocialMediaIcon,
                MasterSocialMediaUrl = data.MasterSocialMediaUrl,
                CreateDate = data.CreateDate,
                CreateUser = data.CreateUser,
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                IsActive = data.IsActive,
                IsDelete = data.IsDelete,


            };
            return View(Res); ;
        }


        // POST: MasterSocialMediumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSocialMediumModel collection)
        {
            try
            {
                string ImageName = UploadImage(collection.File);

                var data = new MasterSocialMedium
                {
                    MasterSocialMediumId = collection.MasterSocialMediumId,
                    MasterSocialMediaIcon = (ImageName != "") ? ImageName : collection.MasterSocialMediaIcon,
                    MasterSocialMediaUrl = collection.MasterSocialMediaUrl,
                    CreateDate = collection.CreateDate,
                    CreateUser = collection.CreateUser,
                    EditDate = DateTime.Now,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = collection.IsActive,
                    IsDelete = collection.IsDelete,


                };
                MasterSocialMedium.Update(id, data);
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
