using Restaurant.Models;
using Restaurant.ViewModels;


namespace Restaurant.ViewModels
{
    public class MasterCategoryMenuModel   : BaseEntityModel
    {
        public List<MasterCategoryMenu>? ListCategoryMenu { get; set; }
        public int MasterCategoryMenuId { get; set; }
        public string? MasterCategoryMenuName { get; set; }

    }
}
