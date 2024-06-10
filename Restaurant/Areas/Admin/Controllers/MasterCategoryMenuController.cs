using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Authorize]


    [Area("Admin")]

    public class MasterCategoryMenuController : Controller
    {
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }

        public MasterCategoryMenuController(IRepository<MasterCategoryMenu> _MasterCategoryMenu)
        {
            MasterCategoryMenu = _MasterCategoryMenu;
        }

        // GET: MasterCategoryMenuController
        //[Area("Admin")]

        public ActionResult Index(int idDelete)
        {

            MasterCategoryMenuModel obj = new MasterCategoryMenuModel();
            if (idDelete != 0)
            {
                MasterCategoryMenu data = new MasterCategoryMenu()
                {
                    EditDate = DateTime.UtcNow,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    //CreateDate = obj.CreateDate,
                    //CreateUser = obj.CreateUser,
                    //IsActive = true,
                    //IsDelete = false
                };

                MasterCategoryMenu.Delete(idDelete, data);
                return RedirectToAction(nameof(Index));


            }
            obj.ListCategoryMenu = MasterCategoryMenu.view().ToList();

            return View(obj);
        }



        // GET: MasterCategoryMenuController/Create


        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterCategoryMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterCategoryMenu collection)
        {
            try
            {

                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.CreateDate = DateTime.UtcNow;
                collection.IsActive = true;
                MasterCategoryMenu.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCategoryMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterCategoryMenu.find(id);
            return View(data);
        }

        // POST: MasterCategoryMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterCategoryMenu collection)
        {
            try
            {

                collection.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.EditDate = DateTime.Now;
                MasterCategoryMenu.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Search(string strName)
        {
            MasterCategoryMenuModel obj = new MasterCategoryMenuModel();

            if (strName == null)
            {

                return RedirectToAction(nameof(Index));
            }
            var data = MasterCategoryMenu.Search(strName);
            if (data.Count <= 0)
            {

                return RedirectToAction(nameof(Index));
            }
            obj.ListCategoryMenu = data;

            return View(viewName: "Index", obj);



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
    }
}
