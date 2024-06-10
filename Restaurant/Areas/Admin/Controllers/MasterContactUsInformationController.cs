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

    public class MasterContactUsInformationController : Controller
    {
        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterContactUsInformationController(IRepository<MasterContactUsInformation> _MasterContactUsInformation , 
            Microsoft.AspNetCore.Hosting.IHostingEnvironment _Host)
        {
            MasterContactUsInformation = _MasterContactUsInformation;
            Host = _Host;
        }

        // GET: MasterContactUsInformationController
        public ActionResult Index(int idDelete)
        {

            MasterContactUsInformationModel obj = new MasterContactUsInformationModel();
            if (idDelete != 0)
            {
                MasterContactUsInformation data = new MasterContactUsInformation()
                {
                    EditDate = DateTime.UtcNow,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreateDate = obj.CreateDate,
                    CreateUser = obj.CreateUser,
                };

                MasterContactUsInformation.Delete(idDelete, data);
                return RedirectToAction(nameof(Index));


            }
            obj.ListMasterContactUsInformation = MasterContactUsInformation.view().ToList();

            return View(obj);
        }

    

        // GET: MasterContactUsInformationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterContactUsInformationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterContactUsInformationModel collection)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please Enter The Reqierd Field");

                    return View();

                }
                MasterContactUsInformation data = new MasterContactUsInformation
                {
                    MasterContactUsInformationId = collection.MasterContactUsInformationId,
                    MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc,
                    MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect,
                    MasterContactUsInformationIconUrl= collection.MasterContactUsInformationIconUrl,
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                 
            };

                MasterContactUsInformation.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterContactUsInformation.find(id);

            var Res = new MasterContactUsInformationModel
            {
                MasterContactUsInformationId = data.MasterContactUsInformationId,
                MasterContactUsInformationIdesc = data.MasterContactUsInformationIdesc,
                MasterContactUsInformationRedirect = data.MasterContactUsInformationRedirect,
                MasterContactUsInformationIconUrl=data.MasterContactUsInformationIconUrl,
                CreateDate = data.CreateDate,
                CreateUser = data.CreateUser,
                IsActive = data.IsActive,
                IsDelete = data.IsDelete,


            };
            return View(Res); ;
        }

        // POST: MasterContactUsInformationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterContactUsInformationModel collection)
        {
            try
            {
                var data = new MasterContactUsInformation
                {
                    MasterContactUsInformationId = collection.MasterContactUsInformationId,
                    MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc,
                    MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect,
                    MasterContactUsInformationIconUrl=collection.MasterContactUsInformationIconUrl,
                    CreateDate = collection.CreateDate,
                    CreateUser = collection.CreateUser,
                    EditDate = DateTime.Now,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                  
                    IsActive = collection.IsActive,
                    IsDelete = collection.IsDelete,


                };
                MasterContactUsInformation.Update(id, data);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Delete/5
       
        String UploadImage(IFormFile File)
        {

            String ImageName = "";
            if (File != null)

            {
                string pathImage = Path.Combine(Host.WebRootPath,"ImageApp");
                FileInfo fa = new FileInfo(File.FileName);

                ImageName = "Image_" + Guid.NewGuid() + fa.Extension;

                string FullPath = Path.Combine(pathImage, ImageName);
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }


            return ImageName;
        }
        public ActionResult Search(string strName)
        {
            MasterContactUsInformationModel obj = new MasterContactUsInformationModel();

            if (strName == null)
            {

                return RedirectToAction(nameof(Index));
            }
            var data = MasterContactUsInformation.Search(strName);
            if (data.Count <= 0)
            {

                return RedirectToAction(nameof(Index));
            }
            obj.ListMasterContactUsInformation = data;

            return View(viewName: "Index", obj);



        }


        public ActionResult Active(int id)
        {
            MasterContactUsInformation.Active(id, new MasterContactUsInformation()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
