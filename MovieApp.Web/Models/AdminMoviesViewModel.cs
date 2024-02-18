using MovieApp.Web.Entity;
using System.Collections.Generic;

namespace MovieApp.Web.Models;

public class AdminMoviesViewModel
{

    public List<AdminMovieViewModel> Movies { get; set; }
}

public class AdminMovieViewModel
{

    public int MovieId { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public List<Genre> Genres { get; set; }
}
