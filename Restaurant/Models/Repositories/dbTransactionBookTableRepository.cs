using Restaurant.Models;

namespace Restaurant.Models.Repositories
{
    public class dbTransactionBookTableRepository : IRepository<TransactionBookTable>
    {
        AppDbContext Db;


        public dbTransactionBookTableRepository(AppDbContext _db)
        {

            Db = _db;
        }

        public List<TransactionBookTable> Search(string strName)
        {
            return Db.TransactionBookTable.Where(x => x.TransactionBookTableFullName.ToLower().Contains(strName.ToLower())).ToList();
        }


        public void Active(int id, TransactionBookTable entity)
        {
            TransactionBookTable data = find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(TransactionBookTable entity)
        {
            Db.TransactionBookTable.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, TransactionBookTable entity)
        {
            TransactionBookTable data = find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);

        }

        public TransactionBookTable find(int id)
        {
            return Db.TransactionBookTable.SingleOrDefault(x => x.TransactionBookTableId == id);
        }

        public void Update(int id, TransactionBookTable entity)
        {
            Db.TransactionBookTable.Update(entity);
            Db.SaveChanges();
        }

        public IList<TransactionBookTable> view()
        {

            return Db.TransactionBookTable.Where(data => !data.IsDelete).ToList();

        }


        public IList<TransactionBookTable> viewFromClient()
        {
            return Db.TransactionBookTable.Where(data => !data.IsDelete && data.IsActive).ToList();
        }
    }
}
