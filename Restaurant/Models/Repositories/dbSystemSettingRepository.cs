using Restaurant.Models;

namespace Restaurant.Models.Repositories
{
    public class dbSystemSettingRepository : IRepository<SystemSetting>
    {
        AppDbContext Db;


        public dbSystemSettingRepository(AppDbContext _db)
        {

            Db = _db;
        }

        public List<SystemSetting> Search(string strName)
        {
            return Db.SystemSetting.Where(x => x.SystemSettingWelcomeNoteTitle.ToLower().Contains(strName.ToLower())).ToList();
        }


        public void Active(int id, SystemSetting entity)
        {
            SystemSetting data = find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(SystemSetting entity)
        {
            Db.SystemSetting.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, SystemSetting entity)
        {
            SystemSetting data = find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);

        }

        public SystemSetting find(int id)
        {
            return Db.SystemSetting.SingleOrDefault(x => x.SystemSettingId == id);
        }

        public void Update(int id, SystemSetting entity)
        {
            Db.SystemSetting.Update(entity);
            Db.SaveChanges();
        }

        public IList<SystemSetting> view()
        {

            return Db.SystemSetting.Where(data => !data.IsDelete).ToList();

        }


        public IList<SystemSetting> viewFromClient()
        {
            return Db.SystemSetting.Where(data => !data.IsDelete && data.IsActive).ToList();
        }
    }
}
