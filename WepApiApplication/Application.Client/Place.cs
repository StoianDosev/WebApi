﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Client
{
    public class Place
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string Description { get; set; }
    }
}
