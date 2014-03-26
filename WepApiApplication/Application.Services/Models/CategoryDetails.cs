using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Application.Services.Models
{
    [DataContract(Name = "Category")]
    public class CategoryDetails
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name="Created")]
        public string CreatedOn { get; set; }

        [DataMember(Name = "places")]
        public IEnumerable<PlaceModel> Places { get; set; }
    }
}