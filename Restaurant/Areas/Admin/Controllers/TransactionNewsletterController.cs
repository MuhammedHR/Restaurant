using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using System.Security.Claims;
using Microsoft.VisualBasic;
using Restaurant.ViewModels;

namespace Restaurant.Areas.Admin.Controllers
{
    [Authorize]

    [Area("Admin")]
    public class TransactionNewsletterController : Controller
    {
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }

        public TransactionNewsletterController(IRepository<TransactionNewsletter> _TransactionNewsletter)
        {
            TransactionNewsletter = _TransactionNewsletter;
        }

        public ActionResult Search(string strName)
        {
            TransactionNewsletterModel obj = new TransactionNewsletterModel();

            if (strName == null)
            {

                return RedirectToAction(nameof(Index));
            }
            var data = TransactionNewsletter.Search(strName);
            if (data.Count <= 0)
            {

                return RedirectToAction(nameof(Index));
            }
            obj.ListTransactionNewsletter = data;

            return View(viewName: "Index", obj);



        }

        // GET: TransactionNewsletterController
        public ActionResult Index()
        {
            var data = TransactionNewsletter.view();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            TransactionNewsletter.Active(id, new TransactionNewsletter()
            {
                EditDate = DateTime.Now,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }



        // GET: TransactionContactUController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionContactUController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionNewsletter collection)
        {
            try
            {


                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.IsActive = true;

                
                TransactionNewsletter.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionContactUController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = TransactionNewsletter.find(id);
            return View(data);
        }

        // POST: TransactionContactUController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionNewsletter collection)
        {
            try
            {
                TransactionNewsletter.Update(id, collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
