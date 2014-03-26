using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataLayer
{
    public class NewPlacesContext: DbContext
    {
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public NewPlacesContext()
            : base("NewPlacesDb")
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>()
        //                .Property(c => c.Name)
        //                .IsRequired();

        //    modelBuilder.Entity<Comment>()
        //                .Property(c => c.Text)
        //                .IsRequired();
        //    modelBuilder.Entity<Comment>()
        //                .Property(c => c.UserName)
        //                .IsRequired()
        //                .HasMaxLength(30);

        //    modelBuilder.Entity<Place>()
        //                .Property(p => p.Name)
        //                .IsRequired()
        //                .HasMaxLength(40);
        //    modelBuilder.Entity<Place>()
        //                .Property(p => p.Latitude)
        //                .IsRequired();
        //    modelBuilder.Entity<Place>()
        //                .Property(p => p.Longitude)
        //                .IsRequired();

        //    modelBuilder.Entity<Vote>()
        //                .Property(v => v.Value)
        //                .IsRequired();

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
