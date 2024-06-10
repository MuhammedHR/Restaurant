using Restaurant.Models;

namespace Restaurant.Models.Repositories
{
    public class dbMasterSliderRepository : IRepository<MasterSlider>
    {
        AppDbContext Db;


        public dbMasterSliderRepository(AppDbContext _db)
        {

            Db = _db;
        }


        public void Active(int id, MasterSlider entity)
        {
            MasterSlider data = find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterSlider entity)
        {
            Db.MasterSlider.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterSlider entity)
        {
            MasterSlider data = find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);

        }

        public MasterSlider find(int id)
        {
            return Db.MasterSlider.SingleOrDefault(x => x.MasterSliderId == id);
        }

        public void Update(int id, MasterSlider entity)
        {
            Db.MasterSlider.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterSlider> view()
        {

            return Db.MasterSlider.Where(data => !data.IsDelete).ToList();

        }


        public IList<MasterSlider> viewFromClient()
        {
            return Db.MasterSlider.Where(data => !data.IsDelete && data.IsActive).ToList();
        }
        public List<MasterSlider> Search(string strName)
        {
            return Db.MasterSlider.Where(x => x.MasterSliderTitle.ToLower().Contains(strName.ToLower())).ToList();
        }
    }
}
