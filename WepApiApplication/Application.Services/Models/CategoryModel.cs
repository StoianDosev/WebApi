using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Application.Services.Models
{
    [DataContract(Name = "Category")]
    public class CategoryModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name="created")]
        public string CreatedOn { get; set; }
    }
}