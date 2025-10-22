using System.Collections.Generic;

namespace LibreriaDigital.Application.DTOs
{
    public class UserDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<string> BookTitles { get; set; } = new List<string>();
    }
}