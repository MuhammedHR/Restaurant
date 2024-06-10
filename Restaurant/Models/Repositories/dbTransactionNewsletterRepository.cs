namespace Restaurant.Models.Repositories
{
    public class dbTransactionNewsletterRepository : IRepository<TransactionNewsletter>
    {
        AppDbContext Db;


        public dbTransactionNewsletterRepository(AppDbContext _db)
        {

            Db = _db;
        }
        public List<TransactionNewsletter> Search(string strName)
        {
            return Db.TransactionNewsletter.Where(x => x.TransactionNewsletterEmail.ToLower().Contains(strName.ToLower())).ToList();
        }


        public void Active(int id, TransactionNewsletter entity)
        {
            TransactionNewsletter data = find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(TransactionNewsletter entity)
        {
            Db.TransactionNewsletter.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, TransactionNewsletter entity)
        {
            TransactionNewsletter data = find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);

        }

        public TransactionNewsletter find(int id)
        {
            return Db.TransactionNewsletter.SingleOrDefault(x => x.TransactionNewsletterId == id);
        }

        public void Update(int id, TransactionNewsletter entity)
        {
            Db.TransactionNewsletter.Update(entity);
            Db.SaveChanges();
        }

        public IList<TransactionNewsletter> view()
        {

            return Db.TransactionNewsletter.Where(data => !data.IsDelete).ToList();

        }


        public IList<TransactionNewsletter> viewFromClient()
        {
            return Db.TransactionNewsletter.Where(data => !data.IsDelete && data.IsActive).ToList();
        }
    }
}
