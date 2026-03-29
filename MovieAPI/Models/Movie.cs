using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{ 
    public class Movie
    {
        //Add Model validation attributes

        public int Id { get; set; }
        
        [Required(ErrorMessage = "Title is required.")]
        [RegularExpression(@"^[A-Z].*", ErrorMessage = "Title must start with a capital letter.")]
        public string Title { get; set; } 
        
        [Required(ErrorMessage = "Release Year is required.")]
        [Range(1900, 2025, ErrorMessage = "Release Year must be between 1900 and 2025.")]
        public string ReleaseYear { get; set; }
        
        [Required(ErrorMessage = "Genre is required.")]
        [RegularExpression(@"^(Action|Comedy|Drama|Horror|SciFi)$", ErrorMessage = "Genre must be one of the following values: Action, Comedy, Drama, Horror, SciFi.")]
        public string Genre { get; set; }
        [Display(Name = "Image URL")]
        public string ImgUrl { get; set; }
    }
}
