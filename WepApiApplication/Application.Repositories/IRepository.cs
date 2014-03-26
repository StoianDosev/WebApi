using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRepository<T>
    {
        T Add(T item);
        T Update(int id, T item);
        void Delete(int id);
        T Get(int id);
        IQueryable<T> All();
    }
}
