
using Restaurant.Models;

namespace Restaurant.Models.Repositories
{
    public class dbMasterCategoryMenuRepository : IRepository<MasterCategoryMenu>
    {
        AppDbContext Db;


        public dbMasterCategoryMenuRepository(AppDbContext _db)
        {

            Db = _db; 
        }


        public void Active(int id, MasterCategoryMenu entity)
        {
            MasterCategoryMenu data = find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterCategoryMenu entity)
        {
            Db.MasterCategoryMenu.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id,MasterCategoryMenu entity)
        {
            MasterCategoryMenu data = find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);


        }

        public MasterCategoryMenu find(int id)
        {
            return Db.MasterCategoryMenu.SingleOrDefault(x => x.MasterCategoryMenuId == id);
        }

        public void Update(int id, MasterCategoryMenu entity)
        {
            Db.MasterCategoryMenu.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterCategoryMenu> view()
        {

            return Db.MasterCategoryMenu.Where(data => !data.IsDelete).ToList();

        }


        public IList<MasterCategoryMenu> viewFromClient()
        {
            return Db.MasterCategoryMenu.Where(data => !data.IsDelete && data.IsActive).ToList();
        }


        public List<MasterCategoryMenu> Search(string strName)
        {
            return Db.MasterCategoryMenu.Where(x => x.MasterCategoryMenuName.ToLower().Contains(strName.ToLower())).ToList();
        }
    }
}
