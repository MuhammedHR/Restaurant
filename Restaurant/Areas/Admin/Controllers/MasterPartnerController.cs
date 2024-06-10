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
    public class MasterPartnerController : Controller
    {
        public IRepository<MasterPartner> MasterPartner { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterPartnerController(IRepository<MasterPartner> _MasterPartner,
                Microsoft.AspNetCore.Hosting.IHostingEnvironment _Host)
        {
            MasterPartner = _MasterPartner;
            Host = _Host;
        }

        // GET: MasterPartnerController
        public ActionResult Index(int idDelete)
        {

            MasterPartnerModel obj = new MasterPartnerModel();
            if (idDelete != 0)
            {
                MasterPartner data = new MasterPartner()
                {
                    EditDate = DateTime.UtcNow,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                   CreateDate = obj.CreateDate,
                    CreateUser=obj.CreateUser,
                    IsDelete = false
                };

                MasterPartner.Delete(idDelete, data);
                return RedirectToAction(nameof(Index));


            }
            obj.ListMasterPartner = MasterPartner.view().ToList();

            return View(obj);
        }
        public ActionResult Active(int id)
        {
            MasterPartner.Active(id, new MasterPartner()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }



        // GET: MasterPartnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterPartnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterPartnerModel collection)
        {
            try
            {
                string ImageName = UploadImage(collection.File);


                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please Enter The Reqierd Field");

                    return View();

                }
                MasterPartner data = new MasterPartner
                {
                    MasterPartnerId = collection.MasterPartnerId,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerLogoImageUrl = ImageName,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,

                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,

                };

                MasterPartner.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Search(string strName)
        {
            MasterPartnerModel obj = new MasterPartnerModel();

            if (strName == null)
            {

                return RedirectToAction(nameof(Index));
            }
            var data = MasterPartner.Search(strName);
            if (data.Count <= 0)
            {

                return RedirectToAction(nameof(Index));
            }
            obj.ListMasterPartner = data;

            return View(viewName: "Index", obj);



        }

        // GET: MasterPartnerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterPartner.find(id);

            var Res = new MasterPartnerModel
            {
                MasterPartnerId = data.MasterPartnerId,
                MasterPartnerName = data.MasterPartnerName,
                MasterPartnerWebsiteUrl = data.MasterPartnerWebsiteUrl,
                MasterPartnerLogoImageUrl = data.MasterPartnerLogoImageUrl,
                CreateDate=data.CreateDate,
                CreateUser = data.CreateUser,
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),

                IsActive = data.IsActive,
                IsDelete = data.IsDelete,


            };
            return View(Res); ;
        }

        // POST: MasterPartnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterPartnerModel collection)
        {
            try
            {
                string ImageName = UploadImage(collection.File);

                var data = new MasterPartner
                {
                    MasterPartnerId = collection.MasterPartnerId,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerLogoImageUrl = (ImageName != "") ? ImageName : collection.MasterPartnerLogoImageUrl,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,

                    CreateDate = collection.CreateDate,
                    CreateUser = collection.CreateUser,
                    EditDate = DateTime.Now,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = collection.IsActive,
                    IsDelete = collection.IsDelete,


                };
                MasterPartner.Update(id, data);
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
