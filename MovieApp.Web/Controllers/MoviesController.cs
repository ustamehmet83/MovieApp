using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Data;
using MovieApp.Web.Entity;
using MovieApp.Web.Models;
using System.Collections.Generic;
using System.Linq;


namespace MovieApp.Web.Controllers;

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
}
