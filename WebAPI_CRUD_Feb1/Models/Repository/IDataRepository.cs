namespace WebAPI_CRUD_Feb1.Models.Repository
{
    public interface IDataRepository<TEntity> //TEntity=>any model class
    {
         IEnumerable<TEntity> GetAll(); //IEnumerable=>List

         TEntity GetById(int id);

        IEnumerable<TEntity> GetByName(string name);

        string Add(TEntity entity);

        bool Remove(TEntity entity);

        bool Update(TEntity entity_old,TEntity entity_new);
    }
}
