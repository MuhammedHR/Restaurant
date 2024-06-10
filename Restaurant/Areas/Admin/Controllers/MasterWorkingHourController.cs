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
    public class MasterWorkingHourController : Controller
    {
        public IRepository<MasterWorkingHour> MasterWorkingHour { get; }

        public MasterWorkingHourController(IRepository<MasterWorkingHour> _MasterWorkingHour)
        {
            MasterWorkingHour = _MasterWorkingHour;
        }

        public ActionResult Search(string strName)
        {
            MasterWorkingHourModel obj = new MasterWorkingHourModel();

            if (strName == null)
            {

                return RedirectToAction(nameof(Index));
            }
            var data = MasterWorkingHour.Search(strName);
            if (data.Count <= 0)
            {

                return RedirectToAction(nameof(Index));
            }
            obj.ListMasterWorkingHour = data;

            return View(viewName: "Index", obj);



        }



        // GET: MasterWorkingHourController
        public ActionResult Index(int idDelete)
        {

            MasterWorkingHourModel obj = new MasterWorkingHourModel();
            if (idDelete != 0)
            {
                MasterWorkingHour data = new MasterWorkingHour()
                {
                    EditDate = DateTime.UtcNow,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreateDate = obj.CreateDate,
                    CreateUser = obj.CreateUser,
                    IsDelete = false
                };

                MasterWorkingHour.Delete(idDelete, data);
                return RedirectToAction(nameof(Index));


            }
            obj.ListMasterWorkingHour = MasterWorkingHour.view().ToList();

            return View(obj);
        }

      

        // GET: MasterWorkingHourController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterWorkingHourController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterWorkingHourModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please Enter The Reqierd Field");

                    return View();

                }
                MasterWorkingHour data = new MasterWorkingHour()
                {
                    MasterWorkingHourId = collection.MasterWorkingHourId,
                    MasterWorkingHoursIdName = collection.MasterWorkingHoursIdName,
                    MasterWorkingHoursIdTimeFormTo = collection.MasterWorkingHoursIdTimeFormTo,
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,

                };

                MasterWorkingHour.Add(data);
                return RedirectToAction(nameof(Index));

            }

            catch
            {
                return View();
            }
        }


        public ActionResult Active(int id)
        {
            MasterWorkingHour.Active(id, new MasterWorkingHour()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterWorkingHourController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterWorkingHour.find(id);
            return View(data);
        }

        // POST: MasterWorkingHourController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,MasterWorkingHour collection)
        {
            try
            {
                var data = new MasterWorkingHour
                {
                    MasterWorkingHourId = collection.MasterWorkingHourId,
                    MasterWorkingHoursIdName = collection.MasterWorkingHoursIdName,
                    MasterWorkingHoursIdTimeFormTo = collection.MasterWorkingHoursIdTimeFormTo,
                    EditDate = DateTime.Now,
                    CreateDate = collection.CreateDate,
                    CreateUser = collection.CreateUser,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = collection.IsActive,
                    IsDelete = collection.IsDelete


                };
                MasterWorkingHour.Update(id,data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

 
    }
}
