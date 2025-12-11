using System;
using BookLib.Domain.Enums;
using BookLib.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace BookLib.Domain.Entities
{
    public class UserCurrent
    {
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string? UserPass { get; set; }
        public Genre FavGenre { get; set; }
        public Genre NoGenre { get; set; }
    }
}
