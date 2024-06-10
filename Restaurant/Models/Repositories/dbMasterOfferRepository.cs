using Restaurant.Models;

namespace Restaurant.Models.Repositories
{
    public class dbMasterOfferRepository : IRepository<MasterOffer>
    {
        AppDbContext Db;


        public dbMasterOfferRepository(AppDbContext _db)
        {

            Db = _db;
        }


        public void Active(int id, MasterOffer entity)
        {
            MasterOffer data = find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterOffer entity)
        {
            Db.MasterOffer.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterOffer entity)
        {
            MasterOffer data = find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);

        }

        public MasterOffer find(int id)
        {
            return Db.MasterOffer.SingleOrDefault(x => x.MasterOfferId == id);
        }

        public void Update(int id, MasterOffer entity)
        {
            Db.MasterOffer.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterOffer> view()
        {

            return Db.MasterOffer.Where(data => !data.IsDelete).ToList();

        }


        public IList<MasterOffer> viewFromClient()
        {
            return Db.MasterOffer.Where(data => !data.IsDelete && data.IsActive).ToList();
        }
        public List<MasterOffer> Search(string strName)
        {
            return Db.MasterOffer.Where(x => x.MasterOfferTitle.ToLower().Contains(strName.ToLower())).ToList();
        }
    }
}
