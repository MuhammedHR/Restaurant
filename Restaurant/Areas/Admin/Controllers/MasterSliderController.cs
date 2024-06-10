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
    public class MasterSliderController : Controller
    {
        public IRepository<MasterSlider> MasterSlider { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterSliderController(IRepository<MasterSlider> _MasterSlider,
  Microsoft.AspNetCore.Hosting.IHostingEnvironment _Host)
        {
            MasterSlider = _MasterSlider;
            Host = _Host;
        }
        public ActionResult Search(string strName)
        {
            MasterSliderModel obj = new MasterSliderModel();

            if (strName == null)
            {

                return RedirectToAction(nameof(Index));
            }
            var data = MasterSlider.Search(strName);
            if (data.Count <= 0)
            {

                return RedirectToAction(nameof(Index));
            }
            obj.ListMasterSlider = data;

            return View(viewName: "Index", obj);



        }

        // GET: MasterSliderController
        public ActionResult Index(int idDelete)
        {

            MasterSliderModel obj = new MasterSliderModel();
            if (idDelete != 0)
            {
                MasterSlider data = new MasterSlider()
                {
                    EditDate = DateTime.UtcNow,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreateDate = obj.CreateDate,
                    CreateUser = obj.CreateUser,
                    IsDelete = false
                };

                MasterSlider.Delete(idDelete, data);
                return RedirectToAction(nameof(Index));


            }
            obj.ListMasterSlider = MasterSlider.view().ToList();

            return View(obj);
        }
        public ActionResult Active(int id)
        {
            MasterSlider.Active(id, new MasterSlider()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }



        // GET: MasterSliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSliderModel collection)
        {
            try
            {
                string ImageName = UploadImage(collection.File);


                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please Enter The Reqierd Field");

                    return View();

                }
                MasterSlider data = new MasterSlider
                {
                    MasterSliderId = collection.MasterSliderId,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderUrl = collection.MasterSliderUrl,
                    MasterSliderImage = ImageName,

                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,

                };

                MasterSlider.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSliderController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSlider.find(id);

            var Res = new MasterSliderModel
            {
                MasterSliderId = data.MasterSliderId,
                MasterSliderTitle = data.MasterSliderTitle,
                MasterSliderDesc = data.MasterSliderDesc,
                MasterSliderBreef = data.MasterSliderBreef,
                MasterSliderImage=data.MasterSliderImage,
                MasterSliderUrl = data.MasterSliderUrl,
                CreateDate = data.CreateDate,
                CreateUser = data.CreateUser,
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                IsActive = data.IsActive,
                IsDelete = data.IsDelete,


            };
            return View(Res);
        }

        // POST: MasterSliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSliderModel collection)
        {
            try
            {
                string ImageName = UploadImage(collection.File);


                var data = new MasterSlider
                {
                    MasterSliderId = collection.MasterSliderId,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderUrl = collection.MasterSliderUrl,
                    MasterSliderImage = (ImageName != "") ? ImageName : collection.MasterSliderImage,

                    CreateDate = collection.CreateDate,
                    CreateUser = collection.CreateUser,
                    EditDate = DateTime.Now,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = collection.IsActive,
                    IsDelete = collection.IsDelete,


                };
                MasterSlider.Update(id, data);
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
