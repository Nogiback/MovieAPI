using System.ComponentModel.DataAnnotations;

namespace MovieAPI.DTOs
{
    public class MovieCreateDTO
    {
        [Required(ErrorMessage = "Title is required")]
        [RegularExpression(@"^[A-Z].*", ErrorMessage = "Title must start with a capital letter")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Release year is required")]
        [Range(1900, 2025, ErrorMessage = "Release year must be between 1900 and 2025")]
        public string ReleaseYear { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [RegularExpression("^(Action|Comedy|Drama|Horror|SciFi)$",
            ErrorMessage = "Genre must be one of: Action, Comedy, Drama, Horror, SciFi")]
        public string Genre { get; set; } = string.Empty;

        [Display(Name = "Image URL")]
        [Url(ErrorMessage = "Invalid URL format")]
        public string ImgUrl { get; set; } = string.Empty;
    }
}
