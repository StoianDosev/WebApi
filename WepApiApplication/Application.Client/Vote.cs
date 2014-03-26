using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Client
{
    class Vote
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public string UserName { get; set; }

        public int PlaceId { get; set; }
    }
}
