namespace LibreriaDigital.Application.DTOs
{
    public class BookCreateDto
    {
        // NO se incluye el ID del libro, ya que se genera
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string? ImageLocation { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        
        // Clave foránea con User
        public int UserId { get; set; } 
    }
}