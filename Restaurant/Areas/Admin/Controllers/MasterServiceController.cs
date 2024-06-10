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
    public class MasterServiceController : Controller
    {
        public IRepository<MasterService> MasterService { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterServiceController(IRepository<MasterService> _MasterService,
 Microsoft.AspNetCore.Hosting.IHostingEnvironment _Host)
        {
            MasterService = _MasterService;
            Host = _Host;
        }
        public ActionResult Search(string strName)
        {
            MasterServiceModel obj = new MasterServiceModel();

            if (strName == null)
            {

                return RedirectToAction(nameof(Index));
            }
            var data = MasterService.Search(strName);
            if (data.Count <= 0)
            {

                return RedirectToAction(nameof(Index));
            }
            obj.ListMasterService = data;

            return View(viewName: "Index", obj);



        }

        // GET: MasterServiceController
        public ActionResult Index(int idDelete)
        {

            MasterServiceModel obj = new MasterServiceModel();
            if (idDelete != 0)
            {
                MasterService data = new MasterService()
                {
                    EditDate = DateTime.UtcNow,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreateDate = obj.CreateDate,
                    CreateUser = obj.CreateUser,
                    IsDelete = false
                };

                MasterService.Delete(idDelete, data);
                return RedirectToAction(nameof(Index));


            }
            obj.ListMasterService = MasterService.view().ToList();

            return View(obj);
        }
        public ActionResult Active(int id)
        {
            MasterService.Active(id, new MasterService()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }



        // GET: MasterServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterServiceModel collection)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please Enter The Reqierd Field");

                    return View();

                }
                MasterService data = new MasterService
                {
                    MasterServiceId = collection.MasterServiceId,
                    MasterServicesTitle = collection.MasterServicesTitle,
                    MasterServicesDesc = collection.MasterServicesDesc,
                    MasterServicesIcon = collection.MasterServicesIcon,
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,

                };

                MasterService.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterService.find(id);

            var Res = new MasterServiceModel
            {
                MasterServiceId = data.MasterServiceId,
                MasterServicesDesc = data.MasterServicesDesc,
                MasterServicesTitle = data.MasterServicesTitle,
                MasterServicesIcon = data.MasterServicesIcon,
                CreateDate = data.CreateDate,
                CreateUser = data.CreateUser,
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                IsActive = data.IsActive,
                IsDelete = data.IsDelete,


            };
            return View(Res);
        }

        // POST: MasterServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterServiceModel collection)
        {
            try
            {
                var data = new MasterService
                {
                    MasterServiceId = collection.MasterServiceId,
                    MasterServicesTitle = collection.MasterServicesTitle,
                    MasterServicesDesc = collection.MasterServicesDesc,
                    MasterServicesIcon = collection.MasterServicesIcon,
                    CreateDate = collection.CreateDate,
                    CreateUser = collection.CreateUser,
                    EditDate = DateTime.Now,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = collection.IsActive,
                    IsDelete = collection.IsDelete,


                };
                MasterService.Update(id, data);
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
