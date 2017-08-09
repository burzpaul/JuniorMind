using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace SqlDatabaseApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var context = new ChinookContext())
            {
                return View(context
                    .Artist
                    .Include(a => a.Album)
                    .ToArray());
            }
        }
    }
}