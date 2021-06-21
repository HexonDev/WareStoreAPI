using System.Collections.Generic;

namespace WareStoreAPI.Repositories
{
    public interface IRepository
    {
        ICollection<T> SelectAll<T>() where T : class;
        T SelectById<T>(long id) where T : class;
        void Create<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
    }
}
