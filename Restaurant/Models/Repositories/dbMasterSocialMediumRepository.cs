using Restaurant.Models;

namespace Restaurant.Models.Repositories
{
    public class dbMasterSocialMediumRepository : IRepository<MasterSocialMedium>
    {
        AppDbContext Db;


        public dbMasterSocialMediumRepository(AppDbContext _db)
        {

            Db = _db;
        }
        public List<MasterSocialMedium> Search(string strName)
        {
            return Db.MasterSocialMedium.Where(x => x.MasterSocialMediaUrl.ToLower().Contains(strName.ToLower())).ToList();
        }


        public void Active(int id, MasterSocialMedium entity)
        {
            MasterSocialMedium data = find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterSocialMedium entity)
        {
            Db.MasterSocialMedium.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterSocialMedium entity)
        {
            MasterSocialMedium data = find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);

        }

        public MasterSocialMedium find(int id)
        {
            return Db.MasterSocialMedium.SingleOrDefault(x => x.MasterSocialMediumId == id);
        }

        public void Update(int id, MasterSocialMedium entity)
        {
            Db.MasterSocialMedium.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterSocialMedium> view()
        {

            return Db.MasterSocialMedium.Where(data => !data.IsDelete).ToList();

        }


        public IList<MasterSocialMedium> viewFromClient()
        {
            return Db.MasterSocialMedium.Where(data => !data.IsDelete && data.IsActive).ToList();
        }
    }
}
