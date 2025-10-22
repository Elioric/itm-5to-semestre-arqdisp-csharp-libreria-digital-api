namespace LibreriaDigital.Application.DTOs
{
    public class BookDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

        // Evitar ciclos debido a la relación entre los objetos
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}