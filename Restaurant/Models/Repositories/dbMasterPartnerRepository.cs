using Restaurant.Models;

namespace Restaurant.Models.Repositories
{
    public class dbMasterPartnerRepository : IRepository<MasterPartner>
    {
        AppDbContext Db;


        public dbMasterPartnerRepository(AppDbContext _db)
        {

            Db = _db;
        }


        public void Active(int id, MasterPartner entity)
        {
            MasterPartner data = find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterPartner entity)
        {
            Db.MasterPartner.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterPartner entity)
        {
            MasterPartner data = find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);

        }

        public MasterPartner find(int id)
        {
            return Db.MasterPartner.SingleOrDefault(x => x.MasterPartnerId == id);
        }

        public void Update(int id, MasterPartner entity)
        {
            Db.MasterPartner.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterPartner> view()
        {

            return Db.MasterPartner.Where(data => !data.IsDelete).ToList();

        }


        public IList<MasterPartner> viewFromClient()
        {
            return Db.MasterPartner.Where(data => !data.IsDelete && data.IsActive).ToList();
        }
        public List<MasterPartner> Search(string strName)
        {
            return Db.MasterPartner.Where(x => x.MasterPartnerName.ToLower().Contains(strName.ToLower())).ToList();
        }
    }
}
