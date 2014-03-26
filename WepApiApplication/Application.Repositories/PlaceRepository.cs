using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class PlaceRepository : IRepository<Place>
    {
        private DbSet<Place> entity;
        private DbContext context;

        public PlaceRepository(DbContext context)
        {
            this.context = context;
            this.entity = context.Set<Place>();
        }

        public Place Add(Place item)
        {
            this.entity.Add(item);
            this.context.SaveChanges();
            return item;
        }

        public Place Update(int id, Place item)
        {
            var place = this.entity.Find(id);

            place.Name = item.Name;
            place.Description = item.Description;
            place.Longitude = item.Longitude;
            place.Latitude = item.Latitude;
            place.Categories = item.Categories;
            place.Comments = item.Comments;
            place.Votes = item.Votes;
            this.context.SaveChanges();

            return item;
        }

        public void Delete(int id)
        {
            var item = this.entity.Find(id);
            this.entity.Remove(item);
            context.SaveChanges();
        }

        public Place Get(int id)
        {
            return this.entity.Find(id);
        }

        public IQueryable<Place> All()
        {
            return this.entity;
        }
    }
}
