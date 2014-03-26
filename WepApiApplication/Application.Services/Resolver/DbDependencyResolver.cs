using Application.DataLayer;
using Application.Models;
using Application.Repositories;
using Application.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Application.Services.Resolver
{
    public class DbDependencyResolver : IDependencyResolver
    {
        private static DbContext context = new NewPlacesContext();

        private static IRepository<Category> categoryRepository = new CategoryRepository(context);
        private static IRepository<Comment> commentRepository = new CommentRepository(context);
        private static IRepository<Place> placesRepository = new PlaceRepository(context);
        private static IRepository<Vote> votesRepository = new VoteRepository(context);


        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(CategoriesController))
            {
                return new CategoriesController(categoryRepository);
            }
            else if (serviceType == typeof(CommentsController))
            {
                return new CommentsController(commentRepository);
            }
            else if (serviceType == typeof(PlacesController))
            {
                return new PlacesController(placesRepository);
            }
            else if (serviceType == typeof(VotesController))
            {
                return new VotesController(votesRepository);
            }
            else if (serviceType == typeof(ChangePlaceController))
            {
                return new ChangePlaceController(placesRepository, categoryRepository);
            }
            else if (serviceType == typeof(ChangeCategoryController))
            {
                return new ChangeCategoryController(placesRepository, categoryRepository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}