using Restaurant.Models;

namespace Restaurant.Models.Repositories
{
    public class dbMasterMenuRepository : IRepository<MasterMenu>
    {
        AppDbContext Db;


        public dbMasterMenuRepository(AppDbContext _db)
        {

            Db = _db;
        }


        public void Active(int id, MasterMenu entity)
        {
            MasterMenu data = find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterMenu entity)
        {
            Db.MasterMenu.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterMenu entity)
        {
            MasterMenu data = find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);

        }

        public MasterMenu find(int id)
        {
            return Db.MasterMenu.SingleOrDefault(x => x.MasterMenuId == id);
        }

        public void Update(int id, MasterMenu entity)
        {
            Db.MasterMenu.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterMenu> view()
        {

            return Db.MasterMenu.Where(data => !data.IsDelete).ToList();


        }


        public IList<MasterMenu> viewFromClient()
        {
            return Db.MasterMenu.Where(data => !data.IsDelete && data.IsActive).ToList();
        }
        public List<MasterMenu> Search(string strName)
        {
            return Db.MasterMenu.Where(x => x.MasterMenuName.ToLower().Contains(strName.ToLower())).ToList();
        }
    }
}
