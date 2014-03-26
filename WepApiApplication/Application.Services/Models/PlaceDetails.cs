using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Application.Services.Models
{
    [DataContract(Name = "Place")]
    public class PlaceDetails
    {
        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "latitude")]
        public decimal Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public decimal Longitude { get; set; }

        [DataMember(Name="description")]
        public string Desciption { get; set; }

        [DataMember(Name = "categories")]
        public IEnumerable<CategoryModel> Categories { get; set; }

        [DataMember(Name = "comments")]
        public IEnumerable<CommentModel> Coments { get; set; }

        [DataMember(Name = "votes")]
        public IEnumerable<VoteModel> Votes { get; set; }
    }
}