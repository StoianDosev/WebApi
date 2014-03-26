using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Application.Models
{
    public class Place
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Latitude { get; set; }

        
        public decimal Longitude { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public Place()
        {
            this.Categories = new HashSet<Category>();
            this.Votes = new HashSet<Vote>();
            this.Comments = new HashSet<Comment>();
        }
    }
}
