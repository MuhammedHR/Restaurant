using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Models.Repositories

{
    public class dbMasterItemMenuRepository : IRepository<MasterItemMenu>
    {
        AppDbContext Db;


        public dbMasterItemMenuRepository(AppDbContext _db)
        {

            Db = _db;
        }


        public void Active(int id, MasterItemMenu entity)
        {
            MasterItemMenu data = find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterItemMenu entity)
        {
            Db.MasterItemMenu.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterItemMenu entity)
        {
            MasterItemMenu data = find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);

        }

        public MasterItemMenu find(int id)
        {
            return Db.MasterItemMenu.Include(x => x.MasterCategoryMenu).SingleOrDefault(x => x.MasterItemMenuId == id);
        }

        public void Update(int id, MasterItemMenu entity)
        {
            Db.MasterItemMenu.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterItemMenu> view()
        {

            return Db.MasterItemMenu.Include(x => x.MasterCategoryMenu).Where(data => !data.IsDelete).ToList();

        }


        public IList<MasterItemMenu> viewFromClient()
        {
            return Db.MasterItemMenu.Include(x => x.MasterCategoryMenu).Where(data => !data.IsDelete && data.IsActive).ToList();
        }
        public List<MasterItemMenu> Search(string strName)
        {
            return Db.MasterItemMenu.Where(x => x.MasterItemMenuTitle.ToLower().Contains(strName.ToLower())).ToList();
        }
    }
}
