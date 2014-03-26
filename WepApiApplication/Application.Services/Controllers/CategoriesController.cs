using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application.Models;
using Application.Repositories;
using Application.Services.Models;
using System.Data.Entity;
using Application.DataLayer;

namespace Application.Services.Controllers
{
    public class CategoriesController : ApiController
    {

        private IRepository<Category> categoriesRepository;

       

        public CategoriesController(IRepository<Category> categoryRepository)
        {
            this.categoriesRepository = categoryRepository;
        }

        [HttpGet]
        public IEnumerable<CategoryModel> Get()
        {
            //this.categoriesRepository.Add(new Category() { Name = "New Name 1" });

            var categoryEntity = this.categoriesRepository.All();

            var categoryModel =
                (from catModel in categoryEntity
                 select new CategoryModel()
                 {
                     Id = catModel.Id,
                     Name = catModel.Name,
                     CreatedOn = catModel.CreatedOn,
                 }).ToList();
            return categoryModel;
        }

        [HttpGet]
        public CategoryDetails Get(int id)
        {
            Category categoryEntity = this.categoriesRepository.Get(id);

            CategoryDetails categoryDetails =
                new CategoryDetails()
                 {
                     Id = categoryEntity.Id,
                     Name = categoryEntity.Name,
                     CreatedOn = categoryEntity.CreatedOn,
                     Places = (from places in categoryEntity.Places
                               select new PlaceModel
                               {
                                   Id = places.Id,
                                   Name = places.Name,
                                   Longitude = places.Longitude,
                                   Latitude = places.Latitude,
                               }).ToList()
                 };

            return categoryDetails;
        }

        [HttpPost]
        public HttpResponseMessage Post(CategoryModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Name))
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The category or the name cannot be null.");
                return errResponse;
            }

            var newCategory = new Category()
            {
                Name = model.Name,
                CreatedOn = model.CreatedOn,
            };

            var createdEntity = this.categoriesRepository.Add(newCategory);
            var response = Request.CreateResponse(HttpStatusCode.Created, createdEntity);

            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = createdEntity.Id }));

            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(CategoryModel model, int id)
        {
            if (model == null || string.IsNullOrEmpty(model.Name))
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The category or the name cannot be null.");
                return errResponse;
            }

            var newCategory = new Category()
            {
                Name = model.Name
            };

            var updatedEntity = this.categoriesRepository.Update(id, newCategory);
            var response = Request.CreateResponse(HttpStatusCode.Created, updatedEntity);

            return response;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            this.categoriesRepository.Delete(id);
        }

       
    }
}
