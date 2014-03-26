using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Application.Services.Models
{
    [DataContract(Name = "Vote")]
    public class VoteDetails
    {
        [DataMember(Name="Name")]
        public int Id { get; set; }

        [DataMember(Name="value")]
        public int Value { get; set; }

        [DataMember(Name="userName")]
        public string UserName { get; set; }

        [DataMember(Name="placeId")]
        public int PlaceId { get; set; }

        [DataMember(Name="place")]
        public PlaceModel Place { get; set; }
    }
}