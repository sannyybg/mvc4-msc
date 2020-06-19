using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace musicshop.Models
{
    public class Album
    {
        public int AlbumId { get; set; }

        [Required]
        public string Title { get; set; }


        [Required]
        [Range(1, 900, ErrorMessage = "Please enter the corret Price")]
        public double Price { get; set; }

        public string AlbumUrl { get; set; }

        [MaxLength(4)]
        public int ReleaseYear { get; set; }
        
        public Artist Artist { get; set; }

        public Genre Genre { get; set; }

        public int ArtistId { get; set; }

        public int GenreId { get; set; }

    }
}