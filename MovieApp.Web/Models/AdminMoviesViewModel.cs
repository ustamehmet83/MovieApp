using MovieApp.Web.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Models;

public class AdminMoviesViewModel
{

    public List<AdminMovieViewModel> Movies { get; set; }
}

public class AdminCreateMovieModel
{
    [Display(Name = "Film Adı")]
    [Required(ErrorMessage ="film adı girmelisiniz.")]
    [StringLength(50,MinimumLength =3,ErrorMessage="film adı için 3-50 karakter girmelisiniz")]
    public string Title { get; set; }

    [Display(Name = "Film Açıklama")]
    [Required(ErrorMessage = "film açıklama girmelisiniz.")]
    [StringLength(3000, MinimumLength = 10, ErrorMessage = "film açıklama için 10-3000 karakter girmelisiniz")]
    public string Description { get; set; }
    [Required(ErrorMessage = "En az bir tür bilgisi seçmelisiniz.")]
    public int[] GenreIds { get; set; }

}





public class AdminMovieViewModel
{

    public int MovieId { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public List<Genre> Genres { get; set; }
}
