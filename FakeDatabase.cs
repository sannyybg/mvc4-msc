using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using musicshop.Models;

namespace musicshop
{
    public class FakeDatabase
    {
        private List<Album> _albums;
        private List<Genre> _genres;
        private List<Artist> _artists;

        public List<Album> Albums
        {
            get { return _albums; }
        }

        public List<Artist> Artists

        {
            get { return _artists; }
        }

        public List<Genre> Genres
        {
            get { return _genres; }
        }

        public FakeDatabase()
        {
            InitializeArtists();
            InitializeGenres();
            InitializeAlbums();
        }

     

        private void InitializeArtists()
        {
            _artists = new List<Artist>();

            _artists.Add(new Artist() { Name = "Daft Punk", ArtImgUrl = "dfurl", ArtistId = 1 });
            _artists.Add(new Artist() { Name = "Linkin Park", ArtImgUrl = "dfurl", ArtistId = 2 });
            _artists.Add(new Artist() { Name = "Pink Floyd", ArtImgUrl = "dfurl", ArtistId = 3 });
            _artists.Add(new Artist() { Name = "Led Zeppelin", ArtImgUrl = "dfurl", ArtistId = 4 });
            _artists.Add(new Artist() { Name = "2pac", ArtImgUrl = "dfurl", ArtistId = 5 });
            _artists.Add(new Artist() { Name = "Moby", ArtImgUrl = "dfurl", ArtistId = 5 });
            _artists.Add(new Artist() { Name = "Drake", ArtImgUrl = "dfurl", ArtistId = 7 });
            _artists.Add(new Artist() { Name = "Sia", ArtImgUrl = "dfurl", ArtistId = 8 });
            _artists.Add(new Artist() { Name = "Dr. Dre", ArtImgUrl = "dfurl", ArtistId = 9 });
            _artists.Add(new Artist() { Name = "Coldplay", ArtImgUrl = "dfurl", ArtistId = 10 });
            _artists.Add(new Artist() { Name = "Notorious Big", ArtImgUrl = "dfurl", ArtistId = 11 });
            _artists.Add(new Artist() { Name = "Eminem", ArtImgUrl = "dfurl", ArtistId = 12 });
            _artists.Add(new Artist() { Name = "Rammstein", ArtImgUrl = "dfurl", ArtistId = 13 });
            _artists.Add(new Artist() { Name = "Mac Miller", ArtImgUrl = "dfurl", ArtistId = 14 });



        }

        private void InitializeGenres()
        {
            _genres = new List<Genre>();

            _genres.Add(new Genre() { Name = "Rap", GenreId = 1 }) ;
            _genres.Add(new Genre() { Name = "Electronic", GenreId = 2 });
            _genres.Add(new Genre() { Name = "R&B",  GenreId = 3 });
            _genres.Add(new Genre() { Name = "Hip-Hop" , GenreId = 4 });
            _genres.Add(new Genre() { Name = "Alternative Rock", GenreId = 5  });
            _genres.Add(new Genre() { Name = "Pop", GenreId = 6  });
            _genres.Add(new Genre() { Name = "Classic", GenreId = 7  });
            _genres.Add(new Genre() { Name = "Progressive Rock", GenreId = 8 });
            _genres.Add(new Genre() { Name = "Techno", GenreId = 9 });
            _genres.Add(new Genre() { Name = "House", GenreId = 10 });

        }

        private void InitializeAlbums()
        {
            _albums = new List<Album>();

            _albums.Add(new Album()
            {   
                AlbumId = 1,
                Title = "Human after all",
                Price = 18,
                AlbumUrl = "fw",
                ReleaseYear = 2002,
                Artist = _artists.Where(x => x.Name == "Daft Punk").FirstOrDefault(),
                Genre = _genres.Where(x => x.Name == "Electronic").FirstOrDefault()

            }); 

            _albums.Add(new Album()
            {
                AlbumId = 2,
                Title = "Compton",
                Price = 17,
                AlbumUrl = "fw",
                ReleaseYear = 2015,
                Artist = _artists.Where(x => x.Name == "Dr. Dre").FirstOrDefault(),
                Genre = _genres.Where(x => x.Name == "Rap").FirstOrDefault()

            }); 

            _albums.Add(new Album()
            {
                AlbumId = 3,
                Title = "Viva La Vida",
                Price = 13.99,
                AlbumUrl = "fw",
                ReleaseYear = 2005,
                Artist = _artists.Where(x => x.Name == "Coldplay").FirstOrDefault(),
                Genre = _genres.Where(x => x.Name == "Alternative Rock").FirstOrDefault()

            });

            _albums.Add(new Album()
            {
                AlbumId = 3,
                Title = "Changes",
                Price = 15.70,
                AlbumUrl = "fw",
                ReleaseYear = 1991,
                Artist = _artists.Where(x => x.Name == "2pac").FirstOrDefault(),
                Genre = _genres.Where(x => x.Name == "Rap").FirstOrDefault()

            });
        }

        public void Update(Album editedalbum)
        {
            _albums[editedalbum.AlbumId - 1] = editedalbum;
        }

        public void AddAlbum(Album newedalbum)
        {
            newedalbum.AlbumId = _albums.Count + 1;
            _albums.Add(newedalbum);
        }
    }

}
        