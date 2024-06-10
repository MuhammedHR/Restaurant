using Restaurant.Models;

namespace Restaurant.Models.Repositories

{
    public class dbMasterContactUsInformationRepository : IRepository<MasterContactUsInformation>
    {
        AppDbContext Db;


        public dbMasterContactUsInformationRepository(AppDbContext _db)
        {

            Db = _db;
        }


        public void Active(int id, MasterContactUsInformation entity)
        {
            MasterContactUsInformation data = find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterContactUsInformation entity)
        {
            Db.MasterContactUsInformation.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterContactUsInformation entity)
        {
            MasterContactUsInformation data = find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);

        }

        public MasterContactUsInformation find(int id)
        {
            return Db.MasterContactUsInformation.SingleOrDefault(x => x.MasterContactUsInformationId == id);
        }

        public void Update(int id, MasterContactUsInformation entity)
        {
            Db.MasterContactUsInformation.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterContactUsInformation> view()
        {

            return Db.MasterContactUsInformation.Where(data => !data.IsDelete).ToList();

        }


        public IList<MasterContactUsInformation> viewFromClient()
        {
            return Db.MasterContactUsInformation.Where(data => !data.IsDelete && data.IsActive).ToList();
        }
        public List<MasterContactUsInformation> Search(string strName)
        {
            return Db.MasterContactUsInformation.Where(x => x.MasterContactUsInformationIdesc.ToLower().Contains(strName.ToLower())).ToList();
        }
    }
}

    

