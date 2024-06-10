using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using Restaurant.ViewModels;
using System.ComponentModel.Design;
using System.Security.Claims;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<MasterMenu> MasterMenu { get; }
        public IRepository<MasterSlider> MasterSlider { get; }
        public IRepository<SystemSetting> SystemSetting { get; }
        public IRepository<MasterService> MasterService { get; }
        public IRepository<TransactionBookTable> TransactionBookTable { get; }
        public IRepository<WhatPeopleSay> WhatPeopleSay { get; }
        public IRepository<MasterOffer> MasterOffer { get; }
        public IRepository<MasterPartner> MasterPartner { get; }
        public IRepository<MasterWorkingHour> MasterWorkingHour { get; }
        public IRepository<MasterSocialMedium> MasterSocialMedium { get; }
        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IRepository<TransactionContactU> TransactionContactU { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }
        public IRepository<MasterItemMenu> MasterItemMenu1 { get; }

        public HomeController(IRepository<MasterMenu> _MasterMenu,
            IRepository<MasterSlider> _MasterSlider,
            IRepository<SystemSetting> _SystemSetting,
            IRepository<MasterService> _MasterService,
            IRepository<TransactionBookTable> _TransactionBookTable,
            IRepository<WhatPeopleSay> _WhatPeopleSay,
            IRepository<MasterOffer> _MasterOffer,
            IRepository<MasterPartner> _MasterPartner,
             IRepository<MasterWorkingHour> _MasterWorkingHour,
             IRepository<MasterSocialMedium> _MasterSocialMedium,
             IRepository<MasterContactUsInformation> _MasterContactUsInformation,
             IRepository<TransactionNewsletter> _TransactionNewsletter,
             IRepository<MasterItemMenu> _MasterItemMenu,
             IRepository<TransactionContactU> _TransactionContactU,
              IRepository<MasterCategoryMenu> _MasterCategoryMenu)

        {
            MasterMenu = _MasterMenu;
            MasterSlider = _MasterSlider;
            SystemSetting = _SystemSetting;
            MasterService = _MasterService;
            TransactionBookTable = _TransactionBookTable;
            WhatPeopleSay = _WhatPeopleSay;
            MasterOffer = _MasterOffer;
            MasterPartner = _MasterPartner;
            MasterWorkingHour = _MasterWorkingHour;
            MasterSocialMedium = _MasterSocialMedium;
            MasterContactUsInformation = _MasterContactUsInformation;
            TransactionNewsletter = _TransactionNewsletter;
            MasterItemMenu = _MasterItemMenu;
            TransactionContactU = _TransactionContactU;
            MasterCategoryMenu = _MasterCategoryMenu;
        }

     

        public IActionResult Index()
        {
            HomeModel obj = new HomeModel();
            obj.SystemSetting = SystemSetting.find(1);
            obj.ListWhatPeopleSay = WhatPeopleSay.viewFromClient().ToList();
            obj.Offer = MasterOffer.find(1);
            obj.ListPartner = MasterPartner.viewFromClient().ToList();
            obj.ListMenu = MasterMenu.viewFromClient().ToList();
            obj.ListItemMenu = MasterItemMenu.viewFromClient().ToList();

            obj.ListSlider = MasterSlider.viewFromClient().ToList();
            obj.ListWorkingHour = MasterWorkingHour.viewFromClient().ToList();
            obj.ListSocialMedium = MasterSocialMedium.viewFromClient().ToList();
            obj.ListContactUsInformation=MasterContactUsInformation.viewFromClient().ToList();;



            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTable( HomeModel collection)
        {
            try
            {

                collection.TransactionBookTable.CreateDate = DateTime.UtcNow;
                collection.TransactionBookTable.IsActive = true;
                collection.TransactionBookTable.IsDelete = false;
                TransactionBookTable.Add(collection.TransactionBookTable);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Newsletter(HomeModel collection)
        {
            try
            {

                collection.TransactionNewsletter.CreateDate = DateTime.UtcNow;
                collection.TransactionNewsletter.IsActive = true;
                collection.TransactionNewsletter.IsDelete = false;
                TransactionNewsletter.Add(collection.TransactionNewsletter);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult About()
        {
            HomeModel obj = new HomeModel();
            obj.SystemSetting = SystemSetting.find(1);
            obj.ListMenu = MasterMenu.viewFromClient().ToList();
            obj.ListWorkingHour = MasterWorkingHour.viewFromClient().ToList();
            obj.ListSocialMedium = MasterSocialMedium.viewFromClient().ToList();
            obj.ListContactUsInformation = MasterContactUsInformation.viewFromClient().ToList();
            obj.ListContactUsInformation = MasterContactUsInformation.viewFromClient().ToList() ;
            obj.ListService = MasterService.viewFromClient().ToList();



            return View(obj);
        }

        public IActionResult ContactUS()
        {
            HomeModel obj = new HomeModel();
            obj.SystemSetting = SystemSetting.find(1);
            obj.ListMenu = MasterMenu.viewFromClient().ToList();
            obj.ListWorkingHour = MasterWorkingHour.viewFromClient().ToList();
            obj.ListSocialMedium = MasterSocialMedium.viewFromClient().ToList();
            obj.ListContactUsInformation = MasterContactUsInformation.viewFromClient().ToList();


            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactUS(HomeModel collection)
        {
            try
            {

                collection.TransactionContactU.CreateDate = DateTime.UtcNow;
                collection.TransactionContactU.IsActive = true;
                collection.TransactionContactU.IsDelete = false;
                TransactionContactU.Add(collection.TransactionContactU);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Menu()
        {
            HomeModel obj = new HomeModel();
            obj.SystemSetting = SystemSetting.find(1);
            obj.ListMenu = MasterMenu.viewFromClient().ToList();
            obj.ListWorkingHour = MasterWorkingHour.viewFromClient().ToList();
            obj.ListSocialMedium = MasterSocialMedium.viewFromClient().ToList();
            obj.ListContactUsInformation = MasterContactUsInformation.viewFromClient().ToList();
            obj.ListPartner = MasterPartner.viewFromClient().ToList();
            obj.ListCategoryMenu = MasterCategoryMenu.viewFromClient().ToList();
            obj.ListItemMenu = MasterItemMenu.viewFromClient().ToList();





            return View(obj);
        }
        public IActionResult Details(int id)
        {
            HomeModel obj = new HomeModel();
            obj.SystemSetting = SystemSetting.find(1);
            obj.ListMenu = MasterMenu.viewFromClient().ToList();
            obj.ListWorkingHour = MasterWorkingHour.viewFromClient().ToList();
            obj.ListSocialMedium = MasterSocialMedium.viewFromClient().ToList();
            obj.ListContactUsInformation = MasterContactUsInformation.viewFromClient().ToList();
            obj.ListPartner = MasterPartner.viewFromClient().ToList();
            obj.ListCategoryMenu = MasterCategoryMenu.viewFromClient().ToList();
            obj.ListItemMenu = MasterItemMenu.viewFromClient().ToList();
            obj.MasterItemMenu = MasterItemMenu.find(id);







            return View(obj);
        }

    }
}
