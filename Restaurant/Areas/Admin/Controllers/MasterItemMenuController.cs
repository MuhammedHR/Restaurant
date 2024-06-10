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
    public class MasterItemMenuController : Controller
    {
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterItemMenuController(IRepository<MasterItemMenu> _MasterItemMenu, IRepository<MasterCategoryMenu> _MasterCategoryMenu,
         Microsoft.AspNetCore.Hosting.IHostingEnvironment _Host)
        {
            MasterItemMenu = _MasterItemMenu;
            MasterCategoryMenu = _MasterCategoryMenu;
            Host = _Host;
        }


        public ActionResult Active(int id)
        {
            MasterCategoryMenu.Active(id, new MasterCategoryMenu()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Search(string strName)
        {
            MasterItemMenuModel obj2 = new MasterItemMenuModel();
            if (strName == null)
            {

                return RedirectToAction(nameof(Index));
            }
            var data = MasterItemMenu.Search(strName);
            if (data.Count <= 0)
            {

                return RedirectToAction(nameof(Index));
            }
            List<MasterItemMenu> newData = new List<MasterItemMenu>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterItemMenu obj = new MasterItemMenu();
                obj.MasterItemMenuId = data[i].MasterItemMenuId;
                obj.MasterItemMenuDesc = data[i].MasterItemMenuDesc;
                obj.MasterItemMenuTitle = data[i].MasterItemMenuTitle;
                obj.MasterItemMenuDate = data[i].MasterItemMenuDate;
                obj.MasterItemMenuImageUrl = data[i].MasterItemMenuImageUrl;
                obj.MasterItemMenuPrice = data[i].MasterItemMenuPrice;
                obj.MasterCategoryMenuId = data[i].MasterCategoryMenuId;




                obj.MasterCategoryMenu = MasterCategoryMenu.find((int)obj.MasterCategoryMenuId);


                newData.Add(obj);
            }
            obj2.ListMasterItemMenu = newData;

            return View(viewName: "Index", obj2);
        }




        // GET: MasterItemMenuController
        public ActionResult Index(int idDelete)
        {

            MasterItemMenuModel obj = new MasterItemMenuModel();
            if (idDelete != 0)
            {
                MasterItemMenu data = new MasterItemMenu()
                {
                    EditDate = DateTime.UtcNow,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreateDate = obj.CreateDate,
                    CreateUser = obj.CreateUser,
                    IsActive = true,
                    IsDelete = false
                };

                MasterItemMenu.Delete(idDelete, data);
                return RedirectToAction(nameof(Index));


            }
            obj.ListMasterItemMenu = MasterItemMenu.view().ToList();

            return View(obj);
        }

      

        // GET: MasterItemMenuController/Create
        public ActionResult Create()
        {
            var data = MasterCategoryMenu.view();
            ViewBag.MasterCategoryMenu = data;
            return View();
        }

        // POST: MasterItemMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterItemMenuModel collection)
        {
            try
            { 
             string ImageName = UploadImage(collection.File);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please Enter The Reqierd Field");

                return View();

            }
            MasterItemMenu data = new MasterItemMenu
            {
                MasterItemMenuId = collection.MasterItemMenuId,
                MasterItemMenuBreef = collection.MasterItemMenuBreef,
                MasterItemMenuDate = collection.MasterItemMenuDate,
                MasterItemMenuDesc = collection.MasterItemMenuDesc,
                MasterItemMenuPrice = collection.MasterItemMenuPrice,
                MasterItemMenuTitle = collection.MasterItemMenuTitle,
                MasterCategoryMenuId = collection.MasterCategoryMenuId,
                MasterItemMenuImageUrl = ImageName,
                CreateDate = DateTime.Now,
                CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                IsActive = true,

            };

                MasterItemMenu.Add(data);
            return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data2 = MasterCategoryMenu.view();
            ViewBag.MasterCategoryMenu = data2;


            var data = MasterItemMenu.find(id);
            var Res = new MasterItemMenuModel
            {

                MasterItemMenuId = data.MasterItemMenuId,
                MasterItemMenuDesc = data.MasterItemMenuDesc,
                MasterItemMenuBreef = data.MasterItemMenuBreef,
                MasterItemMenuImageUrl = data.MasterItemMenuImageUrl,
                MasterItemMenuPrice = data.MasterItemMenuPrice,
                MasterItemMenuDate = data.MasterItemMenuDate,
                MasterItemMenuTitle = data.MasterItemMenuTitle,
                MasterCategoryMenuId = data.MasterCategoryMenuId,
                CreateDate = data.CreateDate,
                CreateUser = data.CreateUser,
                IsActive = data.IsActive,
                IsDelete = data.IsDelete,
            };
            return View(Res);


        }

        // POST: MasterItemMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterItemMenuModel collection)
        {
            try
            {
                string ImageName = UploadImage(collection.File);

                var data = new MasterItemMenu
                {
                    MasterItemMenuId = collection.MasterItemMenuId,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,
                    MasterItemMenuDate = collection.MasterItemMenuDate,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterItemMenuImageUrl = (ImageName != "") ? ImageName : collection.MasterItemMenuImageUrl,
                    CreateDate = collection.CreateDate,
                    CreateUser = collection.CreateUser,
                    EditDate = DateTime.Now,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = collection.IsActive,
                    IsDelete = collection.IsDelete,
                };
                MasterItemMenu.Update(id, data);
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
