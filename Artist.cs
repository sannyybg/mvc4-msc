using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace musicshop.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public string ArtImgUrl { get; set; }
    }
}