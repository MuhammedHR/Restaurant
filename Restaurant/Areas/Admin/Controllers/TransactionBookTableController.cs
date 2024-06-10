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
    public class TransactionBookTableController : Controller
    {
        public IRepository<TransactionBookTable> TransactionBookTable { get; }

        public TransactionBookTableController(IRepository<TransactionBookTable> _TransactionBookTable)
        {
            TransactionBookTable = _TransactionBookTable;
        }

        public ActionResult Search(string strName)
        {
            TransactionBookTableModel obj = new TransactionBookTableModel();

            if (strName == null)
            {

                return RedirectToAction(nameof(Index));
            }
            var data = TransactionBookTable.Search(strName);
            if (data.Count <= 0)
            {

                return RedirectToAction(nameof(Index));
            }
            obj.ListTransactionBookTable = data;

            return View(viewName: "Index", obj);



        }
        // GET: TransactionBookTableController
        public ActionResult Index()
        {
            var data = TransactionBookTable.view();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            TransactionBookTable.Active(id, new TransactionBookTable()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        // GET: TransactionBookTableController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionBookTableController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionBookTable collection)
        {
            try
            {


                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.IsActive = true;

                TransactionBookTable.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = TransactionBookTable.find(id);
            return View(data);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionBookTable collection)
        {
            try
            {
                TransactionBookTable.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
