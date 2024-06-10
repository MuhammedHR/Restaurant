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
    public class MasterMenuController : Controller
    {
        public IRepository<MasterMenu> MasterMenu { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterMenuController(IRepository<MasterMenu> _MasterMenu,
    Microsoft.AspNetCore.Hosting.IHostingEnvironment _Host)
        {
            MasterMenu = _MasterMenu;
            Host = _Host;
        }
        public ActionResult Active(int id)
        {
            MasterMenu.Active(id, new MasterMenu()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }
        // GET: MasterMenuController
        public ActionResult Index(int idDelete)
        {

            MasterMenuModel obj = new MasterMenuModel();
            if (idDelete != 0)
            {
                MasterMenu data = new MasterMenu()
                {
                    EditDate = DateTime.UtcNow,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreateDate = obj.CreateDate,
                    CreateUser = obj.CreateUser,
                    IsActive = true,
                    IsDelete = false
                };

                MasterMenu.Delete(idDelete, data);
                return RedirectToAction(nameof(Index));


            }
            obj.ListMasterMenu = MasterMenu.view().ToList();

            return View(obj);
        }

   

        // GET: MasterMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterMenuModel collection)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please Enter The Reqierd Field");

                    return View();

                }
                MasterMenu data = new MasterMenu
                {
                    MasterMenuId = collection.MasterMenuId,
                    MasterMenuName = collection.MasterMenuName,
                    MasterMenuUrl = collection.MasterMenuUrl,
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,

                };

                MasterMenu.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterMenu.find(id);

            var Res = new MasterMenuModel
            {
                MasterMenuId = data.MasterMenuId,
                MasterMenuName = data.MasterMenuName,
                MasterMenuUrl = data.MasterMenuUrl,
                CreateDate = data.CreateDate,
                CreateUser = data.CreateUser,
                IsActive = data.IsActive,
                IsDelete = data.IsDelete,


            };
            return View(Res); ;
        }

        // POST: MasterMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterMenuModel collection)
        {
            try
            {
                var data = new MasterMenu
                {
                    MasterMenuId = collection.MasterMenuId,
                    MasterMenuName = collection.MasterMenuName,
                    MasterMenuUrl = collection.MasterMenuUrl,
                    CreateDate = collection.CreateDate,
                    CreateUser = collection.CreateUser,
                    EditDate = DateTime.Now,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = collection.IsActive,
                    IsDelete = collection.IsDelete,


                };
                MasterMenu.Update(id, data);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
        
            public ActionResult Search(string strName)
            {
                MasterMenuModel obj = new MasterMenuModel();

                if (strName == null)
                {

                    return RedirectToAction(nameof(Index));
                }
                var data = MasterMenu.Search(strName);
                if (data.Count <= 0)
                {

                    return RedirectToAction(nameof(Index));
                }
                obj.ListMasterMenu = data;

                return View(viewName: "Index", obj);



            }


       
        
    }
}
