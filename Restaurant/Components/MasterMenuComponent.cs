using Restaurant.Models.Repositories;
using Restaurant.Models;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Components
{
    public class MasterMenucomponent : ViewComponent
    {
        public IRepository<MasterMenu> MasterMenu { get; }

        public MasterMenucomponent(IRepository<MasterMenu> _MasterMenu)
        {
            MasterMenu = _MasterMenu;
        }

        public IViewComponentResult Invoke()
        {
            return View(MasterMenu.view());
        }

    }
}
