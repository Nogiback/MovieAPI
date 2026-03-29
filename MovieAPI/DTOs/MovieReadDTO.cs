namespace MovieAPI.DTOs
{
    public class MovieReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ReleaseYear { get; set; } 
        public string Genre { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
    }
}
