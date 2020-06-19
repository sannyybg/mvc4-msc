using musicshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace musicshop.Controllers
{
    public class ManagerController : Controller
    {
        private static FakeDatabase _database = new FakeDatabase();
        public ActionResult Index()
        {
            var albums = _database.Albums;

            return View(albums);
        }

        public ActionResult Edit(int id)
        {
            var album = _database.Albums.Where(x => x.AlbumId == id).FirstOrDefault();
            ViewBag.ArtistId = new SelectList(_database.Artists, "ArtistId", "Name", album.Artist.ArtistId);
            ViewBag.GenreId = new SelectList(_database.Genres, "GenreId", "Name", album.Genre.GenreId);


            return View(album);
        }

        [HttpPost]
        public ActionResult Edit()
        {
            var editedalbum = new Album();



            editedalbum.Title = Request.Form["Title"];
            editedalbum.Price = double.Parse(Request.Form["Price"]);
            editedalbum.AlbumUrl = Request.Form["AlbumUrl"];
            editedalbum.ReleaseYear = int.Parse(Request.Form["ReleaseYear"]);
            editedalbum.AlbumId = int.Parse(Request.Form["AlbumId"]);


            var genreId = int.Parse(Request.Form["GenreId"]);
            var artistId = int.Parse(Request.Form["ArtistId"]);

            editedalbum.Genre = _database.Genres.Where(x => x.GenreId == genreId).FirstOrDefault();
            editedalbum.Artist = _database.Artists.Where(x => x.ArtistId == artistId).FirstOrDefault();

            _database.Update(editedalbum);

            return RedirectToAction("index");
        }

        public ActionResult Create(int id)
        {
            var album = _database.Albums.Where(x => x.AlbumId == id).FirstOrDefault();
            ViewBag.ArtistId = new SelectList(_database.Artists, "ArtistId", "Name", album.Artist.ArtistId);
            ViewBag.GenreId = new SelectList(_database.Genres, "GenreId", "Name", album.Genre.GenreId);


            return View(album);
        }

        public ActionResult CreateAdd()
        {

            var newedalbum = new Album();

            newedalbum.Title = Request.Form["Title"];
            newedalbum.Price = double.Parse(Request.Form["Price"]);
            newedalbum.AlbumUrl = Request.Form["AlbumUrl"];
            newedalbum.ReleaseYear = int.Parse(Request.Form["ReleaseYear"]);



            var genreId = int.Parse(Request.Form["GenreId"]);
            var artistId = int.Parse(Request.Form["ArtistId"]);

            newedalbum.Genre = _database.Genres.Where(x => x.GenreId == genreId).FirstOrDefault();
            newedalbum.Artist = _database.Artists.Where(x => x.ArtistId == artistId).FirstOrDefault();

            _database.AddAlbum(newedalbum);

            return RedirectToAction("index");
        }

        public ActionResult Search(string parameter)
        {
            var alb = _database.Albums.Where(x => x.Artist.Name.ToLower().Contains(parameter.ToLower()));

            return View("index", alb);
        }

    }

}