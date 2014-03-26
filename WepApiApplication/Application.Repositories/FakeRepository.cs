using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class FakeRepository<T> : IRepository<T>
    {
        public IList<T> entities = new List<T>();

        public T Add(T entity)
        {
            this.entities.Add(entity);
            return entity;
        }

        public T Update(int id, T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            this.entities.RemoveAt(id);
        }

        public T Get(int id)
        {
            return this.entities[id];
        }

        public IQueryable<T> All()
        {
            return this.entities.AsQueryable<T>();
        }
    }
}
