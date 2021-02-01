using System.Collections.Generic;

namespace SIGO.Domain.Common
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(long id);
        void Save(T model);
        void Delete(long id);
        IEnumerable<T> Search(IDictionary<string, object> where, bool strict = true);
    }
}
