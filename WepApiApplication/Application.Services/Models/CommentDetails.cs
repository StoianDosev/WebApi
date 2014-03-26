using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Application.Services.Models
{
    [DataContract(Name = "Comment")]
    public class CommentDetails
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "userName")]
        public string UserName { get; set; }

        [DataMember(Name = "placeId")]
        public int PlaceID { get; set; }

        [DataMember(Name = "places")]
        public PlaceModel Places { get; set; }
    }
}