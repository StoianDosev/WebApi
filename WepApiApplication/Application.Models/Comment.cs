using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string UserName { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }
    }
}
