using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using System.Security.Claims;
using Restaurant.ViewModels;

namespace Restaurant.Areas.Admin.Controllers
{
    [Authorize]

    [Area("Admin")]
    public class TransactionContactUController : Controller
    {
        public IRepository<TransactionContactU> TransactionContactU { get; }

        public TransactionContactUController(IRepository<TransactionContactU> _TransactionContactU)
        {
            TransactionContactU = _TransactionContactU;
        }
        public ActionResult Search(string strName)
        {
            TransactionContactUModel obj = new TransactionContactUModel();

            if (strName == null)
            {

                return RedirectToAction(nameof(Index));
            }
            var data = TransactionContactU.Search(strName);
            if (data.Count <= 0)
            {

                return RedirectToAction(nameof(Index));
            }
            obj.ListTransactionContactU = data;

            return View(viewName: "Index", obj);



        }

        // GET: TransactionContactUController
        public ActionResult Index()
        {
            var data = TransactionContactU.view();
            return View(data);
        }

  

        // GET: TransactionContactUController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionContactUController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionContactU collection)
        {
            try
            {


                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.IsActive = true;

                
                TransactionContactU.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Active(int id)
        {
            TransactionContactU.Active(id, new TransactionContactU()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        // GET: TransactionContactUController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = TransactionContactU.find(id);
            return View(data);
        }

        // POST: TransactionContactUController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionContactU collection)
        {
            try
            {
                TransactionContactU.Update(id, collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    
    }
}
