using MovieApp.Web.Entity;
using System.Collections.Generic;

namespace MovieApp.Web.Models;

public class AdminEditMovieViewModel
{

    public int MovieId { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }

    public List<Genre> SelectedGenres { get; set; }
}
