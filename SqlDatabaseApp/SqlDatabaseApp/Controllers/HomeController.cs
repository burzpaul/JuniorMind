using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlDatabaseApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(bool? update)
        {
            using (var context = new ChinookContext())
            {
                return View(context
                   .Artist
                   .Include(a => a.Album)
                   .ToArray());
            }
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Artist artist)
        {
            using (var context = new ChinookContext())
            {
                context.Artist.Add(artist);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet("update")]
        public IActionResult Update(int id)
        {
            using (var context = new ChinookContext())
            {
                return View(context
                    .Artist
                    .Single(a => a.ArtistId == id));
            }
        }

        [HttpPut("update")]
        public IActionResult Update(Artist artist)
        {
            using (var context = new ChinookContext())
            {
                context.Artist.Update(artist);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            using (var context = new ChinookContext())
            {
                var a = context.Artist.Single(ar => ar.ArtistId == id);
                context.Remove(a);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}