using Application.DataLayer;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class CommentRepository: IRepository<Comment>
    {
        private DbContext context;
        private DbSet<Comment> entity;

        public CommentRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of context is required to use this repository.");
            }
            this.context = context;
            this.entity = context.Set<Comment>();
        }

        public Comment Add(Comment item)
        {
            this.entity.Add(item);
            this.context.SaveChanges();
            return item;
        }

        public Comment Update(int id, Comment item)
        {
            this.entity.Find(id).UserName = item.UserName;
            this.entity.Find(id).Text = item.Text;
            this.context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var item = entity.Find(id);

            if (item != null)
            {
                this.entity.Remove(item);
                this.context.SaveChanges();
            }
        }

        public Comment Get(int id)
        {
            var item = this.entity.Find(id);
            if (item == null)
            {
                throw new ArgumentException("The item is not found");
            }
            return item;
        }

        public IQueryable<Comment> All()
        {
            return this.entity; 
        }
    }
}
