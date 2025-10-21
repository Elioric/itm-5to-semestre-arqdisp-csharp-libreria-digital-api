﻿namespace LibreriaDigital.WebApi.Models
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
        public int UserId { get; set; }
    }
}