using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Data;
using MovieApp.Web.Entity;
using MovieApp.Web.Models;
using System.Collections.Generic;
using System.Linq;


namespace MovieApp.Web.Controllers
{
    public class MoviesController : Controller

    {

        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }
        public object Title { get; private set; }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



        //http://localhost:50889/movies/list/1
        [HttpGet]
        public IActionResult List(int? id, string q)
        {

            var movies = _context.Movies.AsQueryable();
            if (id != null)

            {
                movies = movies.Include(m=>m.Genres)
                    .Where(m => m.Genres.Any(g=>g.GenreId==id));
            }

            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(m =>
                m.Title.ToLower().Contains(q.ToLower()) ||
                m.Description.ToLower().Contains(q.ToLower()));
            }

            var model = new MoviesViewModel()
            {
                Movies = movies.ToList()
            };

            return View("Movies", model);
        }

        //http://localhost:50889/movies/details/1
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_context.Movies.Find(id));
        }

        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie m)
        {

            if (ModelState.IsValid)
            {

                //MovieRepository.Add(m);
                _context.Movies.Add(m);
                _context.SaveChanges();
                TempData["Message"] = $"{m.Title} isimli film eklendi";
                //Model Binding
                return RedirectToAction("List");
            }
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View();


        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View(_context.Genres.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Movie m)
        {

            if (ModelState.IsValid)
            {
                _context.Movies.Update(m);
                _context.SaveChanges();
                return RedirectToAction("Details", "Movies", new { @id = m.MovieId });
            }
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View(m);
        }

        public IActionResult Delete(int MovieId, string Title)
        {

            //MovieRepository.Delete(MovieId);
            var entity = _context.Movies.Find(MovieId);
            _context.Movies.Remove(entity);
            _context.SaveChanges();
            TempData["Message"] = $"{Title} isimli film silindi";
            return RedirectToAction("List");
        }
















    }
}
