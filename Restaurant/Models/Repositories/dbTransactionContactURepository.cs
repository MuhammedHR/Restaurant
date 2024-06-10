namespace Restaurant.Models.Repositories
{
    public class dbTransactionContactURepository : IRepository<TransactionContactU>
    {
        AppDbContext Db;


        public dbTransactionContactURepository(AppDbContext _db)
        {

            Db = _db;
        }

        public List<TransactionContactU> Search(string strName)
        {
            return Db.TransactionContactU.Where(x => x.TransactionContactUsFullName.ToLower().Contains(strName.ToLower())).ToList();
        }


        public void Active(int id, TransactionContactU entity)
        {
            TransactionContactU data = find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(TransactionContactU entity)
        {
            Db.TransactionContactU.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, TransactionContactU entity)
        {
            TransactionContactU data = find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);

        }

        public TransactionContactU find(int id)
        {
            return Db.TransactionContactU.SingleOrDefault(x => x.TransactionContactUId == id);
        }

        public void Update(int id, TransactionContactU entity)
        {
            Db.TransactionContactU.Update(entity);
            Db.SaveChanges();
        }

        public IList<TransactionContactU> view()
        {

            return Db.TransactionContactU.Where(data => !data.IsDelete).ToList();

        }


        public IList<TransactionContactU> viewFromClient()
        {
            return Db.TransactionContactU.Where(data => !data.IsDelete && data.IsActive).ToList();
        }
    }
}
