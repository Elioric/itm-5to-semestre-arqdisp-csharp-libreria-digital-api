namespace LibreriaDigital.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string? ImageLocation { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        
        // Clave foránea con User
        public int UserId { get; set; }
        
        // Propiedad de navegación
        public User? User { get; set; }
    }
}