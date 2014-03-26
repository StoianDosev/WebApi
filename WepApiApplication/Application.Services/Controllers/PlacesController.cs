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
    public class PlacesController : ApiController
    {
        private IRepository<Place> placesRepository;

        public PlacesController(IRepository<Place> repository)
        {
            this.placesRepository = repository;
        }

        [HttpGet]
        public IEnumerable<PlaceModel> Get()
        {
            //this.placesRepository.Add(new Place() { Name = "Place", Describtion = "Alalabala", Latitude = 12345, Longitude = 143423 });

            IEnumerable<Place> entityPlaces = this.placesRepository.All();

            IEnumerable<PlaceModel> models =
                (from places in entityPlaces
                 select new PlaceModel
                 {
                     Id = places.Id,
                     Name = places.Name,
                     Latitude = places.Latitude,
                     Longitude = places.Longitude,
                     Description=places.Description,
                 }).ToList();

            return models;
        }

        [HttpGet]
        public PlaceDetails Get(int id)
        {

            Place entityPlace = this.placesRepository.Get(id);

            if (entityPlace == null)
            {
                throw new ArgumentOutOfRangeException("No such element with that id");
            }

            PlaceDetails model = new PlaceDetails()
            {
                Id = entityPlace.Id,
                Name = entityPlace.Name,
                Latitude = entityPlace.Latitude,
                Longitude = entityPlace.Longitude,
                Desciption = entityPlace.Description,
                Categories = (from category in entityPlace.Categories
                              select new CategoryModel()
                              {
                                  Id = category.Id,
                                  Name = category.Name,
                              }).ToList(),
                Coments = (from comment in entityPlace.Comments
                           select new CommentModel()
                           {
                               Id = comment.Id,
                               Text = comment.Text,
                               UserName = comment.UserName,
                               PlaceID = comment.PlaceId,
                           }).ToList(),
                Votes = (from vote in entityPlace.Votes
                         select new VoteModel()
                         {
                             Id = vote.Id,
                             UserName = vote.UserName,
                             Value = vote.Value,
                             PlaceId = vote.PlaceId,
                         }).ToList()
            };
            return model;
        }

        [HttpPost]
        public HttpResponseMessage Post(PlaceModel model)
        {
            if (model == null)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The place the name cannot be null.");
                return errResponse;
            }
            //if( model.Description==null)
            //{
            //    var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The descrition cannot be null.");
            //    return errResponse;
            //}

            

            Place entiyToAdd = new Place()
            {
                Name = model.Name,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Description = model.Description,
            };

            var createdEntity = this.placesRepository.Add(entiyToAdd);

            var response = Request.CreateResponse(HttpStatusCode.Created, createdEntity);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = createdEntity.Id }));

            return response;
        }

        // PUT api/places/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/places/5
        public void Delete(int id)
        {
            this.placesRepository.Delete(id);
        }
    }
}
