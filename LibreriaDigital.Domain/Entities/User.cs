namespace LibreriaDigital.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Propiedad de navegación
        public ICollection<Book>? Books { get; set; } = new List<Book>();
    }
}