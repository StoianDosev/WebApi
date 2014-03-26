using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class CategoryRepository: IRepository<Category>
    {

        private DbContext context;
        private DbSet<Category> entity;

        public CategoryRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of context is required to use this repository.");
            }
            this.context = context;
            this.entity = context.Set<Category>();
        }

        

        public Category Add(Category item)
        {
            this.entity.Add(item);
            this.context.SaveChanges();
            return item;
        }

        public Category Update(int id, Category item)
        {
            this.entity.Find(id).Name = item.Name;
            this.entity.Find(id).Places = item.Places;
            this.context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            //var item = this.entity.Where(x => x.Id == id).FirstOrDefault();
            var item = entity.Find(id);

            if (item != null)
            {
                this.entity.Remove(item);
                this.context.SaveChanges();
            }
        }

        public Category Get(int id)
        {
            var item = this.entity.Find(id);
            if (item == null)
            {
                throw new ArgumentException("The item is not found");
            }
            return item;
        }

        public IQueryable<Category> All()
        {
            return this.entity;
        }
    }
}
