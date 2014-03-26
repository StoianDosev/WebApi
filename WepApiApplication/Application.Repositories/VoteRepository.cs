using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class VoteRepository : IRepository<Vote>
    {
        private DbContext context;
        private DbSet<Vote> entity;

        public VoteRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of context is required to use this repository.");
            }

            this.context = dbContext;
            this.entity = dbContext.Set<Vote>();
        }
        
        public Vote Add(Vote item)
        {
            if (item == null)
            {
                throw new ArgumentException("The item cannot be null.");
            }

            this.entity.Add(item);
            this.context.SaveChanges();
            return item;
        }

        public Vote Update(int id, Vote item)
        {
            this.entity.Find(id).UserName = item.UserName;
            this.entity.Find(id).Value = item.Value;
            this.entity.Find(id).PlaceId = item.PlaceId;
            this.entity.Find(id).Place = item.Place;

            this.context.SaveChanges();

            return item;
        }

        public void Delete(int id)
        {
            var item = this.entity.Find(id);

            if (item == null)
            {
                throw new ArgumentException("The item is not found");
            }

            this.entity.Remove(item);
            this.context.SaveChanges();
        }

        public Vote Get(int id)
        {
            var item = this.entity.Find(id);

            if (item == null)
            {
                throw new ArgumentException("The item is not found");
            }

            return item;
        }

        public IQueryable<Vote> All()
        {
            return this.entity;
        }
    }
}
