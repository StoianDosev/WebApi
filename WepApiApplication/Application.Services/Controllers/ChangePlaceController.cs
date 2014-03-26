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
    public class ChangePlaceController : ApiController
    {

        private IRepository<Category> categoriesRepository;

        private IRepository<Place> placeRepository;

        public ChangePlaceController(IRepository<Place> placeRepository,IRepository<Category> categoryRepository)
        {
            this.placeRepository = placeRepository;
            this.categoriesRepository = categoryRepository;
        }

        [HttpPost]
        public void AddPlaceToCategory(Item item)
        {
            Place place = placeRepository.Get(item.placeId);
            Category category = categoriesRepository.Get(item.categoryId);
            category.Places.Add(place);
            categoriesRepository.Update(item.categoryId, category);
        }

        [HttpDelete]
        public void DeletePlaceFromCategory(Item item)
        {
            Category category = categoriesRepository.Get(item.categoryId);
            Place placeForDelete = category.Places.Where(p => p.Id == item.placeId).FirstOrDefault();
            category.Places.Remove(placeForDelete);
            categoriesRepository.Update(item.categoryId, category);
        }
    }
}
