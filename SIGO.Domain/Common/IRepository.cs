using System.Collections.Generic;

namespace SIGO.Domain.Common
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}
