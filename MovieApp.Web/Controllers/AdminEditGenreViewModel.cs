using MovieApp.Web.Models;
using System.Collections.Generic;

namespace MovieApp.Web.Controllers
{
    internal class AdminEditGenreViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public object Count { get; set; }
        public List<AdminMovieViewModel> Movies { get; internal set; }
    }
}