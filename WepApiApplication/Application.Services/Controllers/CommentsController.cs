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
    public class CommentsController : ApiController
    {

        private IRepository<Comment> commentsRepository;

        public CommentsController(IRepository<Comment> commentRepository)
        {
            this.commentsRepository = commentRepository;
        }

        public IEnumerable<CommentModel> Get()
        {
            //this.commentsRepository.Add(new Comment() {PlaceId=1, Text = "Oppopopo", UserName = "Hitar Petar" });

            var commentEntity = this.commentsRepository.All();
            var commentsModel =
                (from comModel in commentEntity
                 select new CommentModel()
                 {
                     Id = comModel.Id,
                     Text = comModel.Text,
                     UserName = comModel.UserName,
                     PlaceID = comModel.PlaceId,
                 }).ToList();

            return commentsModel;
        }

        public CommentDetails Get(int id)
        {
            Comment commentEntity = this.commentsRepository.Get(id);

            Place place = commentEntity.Place;

            var commentDetails = new CommentDetails()
            {
                Id = commentEntity.Id,
                Text = commentEntity.Text,
                UserName = commentEntity.UserName,
                PlaceID = commentEntity.PlaceId,
                Places = new PlaceModel
                {
                    Id = place.Id,
                    Name = place.Name,
                    Longitude = place.Longitude,
                    Latitude = place.Latitude,
                }
            };

            return commentDetails;
        }

        // POST api/comment
        public HttpResponseMessage Post(CommentModel model)
        {
            if (model == null)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The category or the name cannot be null.");
                return errResponse;
            }

            Comment entity = new Comment()
            {
                Text = model.Text,
                UserName = model.UserName,
                PlaceId = model.PlaceID,
            };
            var createdEntity = this.commentsRepository.Add(entity);

            var response = Request.CreateResponse(HttpStatusCode.Created, createdEntity);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = createdEntity.Id }));
            return response;
        }

        // PUT api/comment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/comment/5
        public void Delete(int id)
        {
            this.commentsRepository.Delete(id);
        }
    }
}
