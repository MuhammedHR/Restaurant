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
    public class MasterOfferController : Controller
    {
        public IRepository<MasterOffer> MasterOffer { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterOfferController(IRepository<MasterOffer> _MasterOffer,
  Microsoft.AspNetCore.Hosting.IHostingEnvironment _Host)
        {
            MasterOffer = _MasterOffer;
            Host = _Host;
        }


        // GET: MasterOfferController
        public ActionResult Index(int idDelete)
        {

            MasterOfferModel obj = new MasterOfferModel();
            if (idDelete != 0)
            {
                MasterOffer data = new MasterOffer()
                {
                    EditDate = DateTime.UtcNow,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreateDate = obj.CreateDate,
                    CreateUser = obj.CreateUser,
                    IsDelete = false
                };

                MasterOffer.Delete(idDelete, data);
                return RedirectToAction(nameof(Index));


            }
            obj.ListMasterOffer = MasterOffer.view().ToList();

            return View(obj);
        }
        public ActionResult Active(int id)
        {
            MasterOffer.Active(id, new MasterOffer()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }


        // GET: MasterOfferController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterOfferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterOfferModel collection)
        {
            try
            {
                string ImageName = UploadImage(collection.File);

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please Enter The Reqierd Field");

                    return View();

                }
                MasterOffer data = new MasterOffer
                {
                    MasterOfferId = collection.MasterOfferId,
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferImageUrl = ImageName,
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,

                };

                MasterOffer.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterOffer.find(id);

            var Res = new MasterOfferModel
            {
                MasterOfferId = data.MasterOfferId,
                MasterOfferTitle = data.MasterOfferTitle,
                MasterOfferBreef = data.MasterOfferBreef,
                MasterOfferDesc = data.MasterOfferDesc,
                MasterOfferImageUrl = data.MasterOfferImageUrl,
                CreateDate = data.CreateDate,
                CreateUser = data.CreateUser,
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                IsActive = data.IsActive,
                IsDelete = data.IsDelete,


            };
            return View(Res); 
        }

        // POST: MasterOfferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterOfferModel collection)
        {
            try
            {
                string ImageName = UploadImage(collection.File);
                var data = new MasterOffer
                {
                    MasterOfferId = collection.MasterOfferId,
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferImageUrl = (ImageName != "") ? ImageName : collection.MasterOfferImageUrl,
                    CreateDate = collection.CreateDate,
                    CreateUser = collection.CreateUser,
                    EditDate = DateTime.Now,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = collection.IsActive,
                    IsDelete = collection.IsDelete,


                };
                MasterOffer.Update(id, data);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Search(string strName)
        {
            MasterOfferModel obj = new MasterOfferModel();

            if (strName == null)
            {

                return RedirectToAction(nameof(Index));
            }
            var data = MasterOffer.Search(strName);
            if (data.Count <= 0)
            {

                return RedirectToAction(nameof(Index));
            }
            obj.ListMasterOffer = data;

            return View(viewName: "Index", obj);


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
