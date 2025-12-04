using BookLib.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookLib.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Please add a title")]
        [MaxLength(100)]
        public string? Title { get; set; }
        [MaxLength(100)]
        public string? Series { get; set; }
        [Required(ErrorMessage = "Please add the author's first name")]
        [MaxLength(100)]
        public string? AuthorFirst { get; set; }
        [Required(ErrorMessage = "Please add the author's last name")]
        [MaxLength(100)]
        public string? AuthorLast { get; set; }
        [Required(ErrorMessage = "Please add a genre")]
        public Genre Genre { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Please add an age level")]
        [MaxLength(50)]
        public string? AgeLevel { get; set; }

    }
}
