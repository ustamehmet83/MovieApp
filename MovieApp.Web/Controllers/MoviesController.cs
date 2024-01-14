using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp.Web.Data;
using MovieApp.Web.Models;
using System.Collections.Generic;
using System.Linq;


namespace MovieApp.Web.Controllers
{
    public class MoviesController : Controller


    {


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



        //http://localhost:50889/movies/list/1
        [HttpGet]
        public IActionResult List(int? id, string q)
        {

            var movies = MovieRepository.Movies;
            if (id != null)
            {
                movies = movies.Where(m => m.GenreId == id).ToList();
            }

            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(m =>
                m.Title.ToLower().Contains(q.ToLower()) ||
                m.Description.ToLower().Contains(q.ToLower())).ToList();
            }

            var model = new MoviesViewModel()
            {
                Movies = movies
            };
            return View("Movies", model);
        }

        //http://localhost:50889/movies/details/1
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(MovieRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie m)
        {

            if (ModelState.IsValid)
            {
                MovieRepository.Add(m);
                TempData["Message"] = $"{m.Title} isimli film eklendi";
                //Model Binding
                return RedirectToAction("List");
            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View();


        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View(MovieRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Movie m)
        {

            if (ModelState.IsValid)
            {
                MovieRepository.Edit(m);
                return RedirectToAction("Details", "Movies", new { @id = m.MovieId });
            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View(m);
        }

        public IActionResult Delete(int MovieId,string Title)
        {

            MovieRepository.Delete(MovieId);
            TempData["Message"] = $"{Title} isimli film silindi";
            return RedirectToAction("List");
        }
















    }
}
