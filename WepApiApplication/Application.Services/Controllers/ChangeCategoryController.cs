using Application.Models;
using Application.Repositories;
using Application.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Application.Services.Controllers
{
    public class ChangeCategoryController : ApiController
    {
        private IRepository<Category> categoriesRepository;

        private IRepository<Place> placeRepository;

        public ChangeCategoryController(IRepository<Place> placeRepository, IRepository<Category> categoryRepository)
        {
            this.placeRepository = placeRepository;
            this.categoriesRepository = categoryRepository;
        }

        

        [HttpPost]
        public void AddCategoryToPlace(Item item)
        {
            Place place = placeRepository.Get(item.placeId);
            Category category = categoriesRepository.Get(item.categoryId);
            place.Categories.Add(category);
            placeRepository.Update(item.placeId, place);
        }

        [HttpDelete]
        public void DeleteCategoryFromPlace(Item item)
        {
            Place place = placeRepository.Get(item.placeId);
            Category categoryForDelete = place.Categories.Where(c => c.Id == item.categoryId).FirstOrDefault();
            place.Categories.Remove(categoryForDelete);
            placeRepository.Update(item.placeId, place);
        }
    }
}
