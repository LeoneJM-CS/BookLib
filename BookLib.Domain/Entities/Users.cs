using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookLib.Domain.Entities
{
    public class Users
    {
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string? UserPass { get; set; }

        public string? FavGenre1 { get; set; }
        public string? FavGenre2 { get; set; }
        public string? FavGenre3 { get; set; }
        public string? NoGenre1 { get; set; }
        public string? NoGenre2 { get; set; }
        public string? NoGenre3 { get; set; }
        public string? PrefAge { get; set; }
    }
}
