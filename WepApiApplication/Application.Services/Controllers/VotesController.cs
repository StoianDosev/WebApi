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
    public class VotesController : ApiController
    {
        private IRepository<Vote> votesRepository;

        public VotesController(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }
        

        public IEnumerable<VoteModel> Get()
        {
            var entity = this.votesRepository.All();

            IEnumerable<VoteModel> model =
                (from vote in entity
                 select new VoteModel()
                 {
                     Id = vote.Id,
                     Value = vote.Value,
                     UserName = vote.UserName,
                     PlaceId = vote.PlaceId,
                 }).ToList();
            return model;
        }

       
        public VoteDetails Get(int id)
        {
            var entity = this.votesRepository.Get(id);
            Place place = entity.Place;

            VoteDetails voteDetails = new VoteDetails()
            {
                Id = entity.Id,
                Value = entity.Value,
                UserName = entity.UserName,
                PlaceId = entity.PlaceId,
                Place = new PlaceModel()
                {
                    Id = place.Id,
                    Name = place.Name,
                    Latitude = place.Latitude,
                    Longitude = place.Longitude,
                }
            };
            return voteDetails;
        }

        // POST api/votes
        public HttpResponseMessage Post(VoteModel model)
        {
            Vote entityToAdd = new Vote()
            {
                Value = model.Value,
                UserName = model.UserName, 
                PlaceId = model.PlaceId,
            };

            var createdEntity = this.votesRepository.Add(entityToAdd);

            var response = Request.CreateResponse(HttpStatusCode.Created, createdEntity);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = createdEntity.Id }));
            return response;
        }

        // PUT api/votes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/votes/5
        public void Delete(int id)
        {
            this.votesRepository.Delete(id);
        }
    }
}
