using Restaurant.Models;

namespace Restaurant.Models.Repositories
{
    public class dbMasterWorkingHourRepository : IRepository<MasterWorkingHour>
    {
        AppDbContext Db;


        public dbMasterWorkingHourRepository(AppDbContext _db)
        {

            Db = _db;
        }
        public List<MasterWorkingHour> Search(string strName)
        {
            return Db.MasterWorkingHour.Where(x => x.MasterWorkingHoursIdName.ToLower().Contains(strName.ToLower())).ToList();
        }

        public void Active(int id, MasterWorkingHour entity)
        {
            MasterWorkingHour data = find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterWorkingHour entity)
        {
            Db.MasterWorkingHour.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterWorkingHour entity)
        {
            MasterWorkingHour data = find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);

        }

        public MasterWorkingHour find(int id)
        {
            return Db.MasterWorkingHour.SingleOrDefault(x => x.MasterWorkingHourId == id);
        }

        public void Update(int id, MasterWorkingHour entity)
        {
            Db.MasterWorkingHour.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterWorkingHour> view()
        {

            return Db.MasterWorkingHour.Where(data => !data.IsDelete).ToList();

        }


        public IList<MasterWorkingHour> viewFromClient()
        {
            return Db.MasterWorkingHour.Where(data => !data.IsDelete && data.IsActive).ToList();
        }
    }
}
