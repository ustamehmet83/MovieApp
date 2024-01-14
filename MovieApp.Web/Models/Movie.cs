using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Models
{
    public class Movie
    {

        public int MovieId { get; set; }
        [Required(ErrorMessage ="film başlığı eklemelisiniz.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "film açıklaması eklemelisiniz.")]
        public string Description { get; set; }
        public string Director { get; set; }
        public string[] Players { get; set; }
        [Required(ErrorMessage = "film url eklemelisiniz.")]
        public string ImageUrl { get; set; }
        [Required]
        public int? GenreId { get; set; }


    }
}
