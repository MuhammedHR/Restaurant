namespace Restaurant.Models.Repositories
{
    public interface IRepository <T>
    {
        void Active ( int id , T entity );

         void Add ( T entity );

        void Delete(int id, T entity);


        T find ( int id );

        void Update(int id, T entity);

        IList<T> view ();


        IList<T> viewFromClient ();

        List<T> Search(string strName);




    }
}
