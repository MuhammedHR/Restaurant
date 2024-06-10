namespace Restaurant.Models.Repositories
{
    public class dbWhatPeopleSayRepository : IRepository<WhatPeopleSay>
    {
        AppDbContext Db;


        public dbWhatPeopleSayRepository(AppDbContext _db)
        {

            Db = _db;
        }


        public void Active(int id, WhatPeopleSay entity)
        {
            WhatPeopleSay data = find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(WhatPeopleSay entity)
        {
            Db.WhatPeopleSay.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, WhatPeopleSay entity)
        {
            WhatPeopleSay data = find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);


        }

        public WhatPeopleSay find(int id)
        {
            return Db.WhatPeopleSay.SingleOrDefault(x => x.WhatPeopleSayId == id);
        }

        public void Update(int id, WhatPeopleSay entity)
        {
            Db.WhatPeopleSay.Update(entity);
            Db.SaveChanges();
        }

        public IList<WhatPeopleSay> view()
        {

            return Db.WhatPeopleSay.Where(data => !data.IsDelete).ToList();

        }


        public IList<WhatPeopleSay> viewFromClient()
        {
            return Db.WhatPeopleSay.Where(data => !data.IsDelete && data.IsActive).ToList();
        }


        public List<WhatPeopleSay> Search(string strName)
        {
            return Db.WhatPeopleSay.Where(x => x.WhatPeopleSayName.ToLower().Contains(strName.ToLower())).ToList();
        }
    }
}
