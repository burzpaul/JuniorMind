using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlDatabaseApp.Controllers
{
    public class HomeController : Controller
    {
        private static IEnumerable<Artist> artists;
        private const string FILE_NAME = "artist.txt";

        public HomeController()
        {
            using (var context = new ChinookContext())
            {
                if (artists == null)
                {
                    artists = (context
                   .Artist
                   .Include(a => a.Album)
                   .Take(10)
                   .ToArray());
                }
            }
        }

        public IActionResult Index(bool? update)
        {
            return View(artists);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Artist artist)
        {
            artists = artists.Union(new[] { artist });
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("update")]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost("update")]
        public IActionResult Update(Artist artist)
        {
            using (var context = new ChinookContext())
            {
                context.Artist.Single(a => a.ArtistId == artist.ArtistId).Name = artist.Name;
                artists.Single(a => a.ArtistId == artist.ArtistId).Name = artist.Name;
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Delete(int id)
        {
            using (var context = new ChinookContext())
            {
                context.Artist.Single(a => a.ArtistId == id).Name = null;
                artists.Single(a => a.ArtistId == id).Name = null;
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
        }

        private IEnumerable<Artist> LoadArtists()
        {
            if (!System.IO.File.Exists(FILE_NAME))
            {
                return Enumerable.Empty<Artist>();
            }
            return System.IO.File.ReadAllLines(FILE_NAME).Select(l =>
            {
                var items = l.Split(new[] { '|' });
                return new Artist { ArtistId = int.Parse(items[0]), Name = items[1] };
            });
        }

        private void SaveNotes(IEnumerable<Artist> value)
        {
            System.IO.File.WriteAllLines(FILE_NAME, value.Select(n => $"{n.ArtistId}|{n.Name}|{n.Album.TakeWhile(i => i.ArtistId == n.ArtistId)}"));
        }
    }
}