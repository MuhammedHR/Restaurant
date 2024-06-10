using Restaurant.Models;

namespace Restaurant.Models.Repositories
{
    public class dbMasterServiceRepository : IRepository<MasterService>
    {
        AppDbContext Db;


        public dbMasterServiceRepository(AppDbContext _db)
        {

            Db = _db;
        }


        public void Active(int id, MasterService entity)
        {
            MasterService data = find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterService entity)
        {
            Db.MasterService.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterService entity)
        {
            MasterService data = find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);

        }

        public MasterService find(int id)
        {
            return Db.MasterService.SingleOrDefault(x => x.MasterServiceId == id);
        }

        public void Update(int id, MasterService entity)
        {
            Db.MasterService.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterService> view()
        {

            return Db.MasterService.Where(data => !data.IsDelete).ToList();

        }


        public IList<MasterService> viewFromClient()
        {
            return Db.MasterService.Where(data => !data.IsDelete && data.IsActive).ToList();
        }
        public List<MasterService> Search(string strName)
        {
            return Db.MasterService.Where(x => x.MasterServicesTitle.ToLower().Contains(strName.ToLower())).ToList();
        }
    }
}
