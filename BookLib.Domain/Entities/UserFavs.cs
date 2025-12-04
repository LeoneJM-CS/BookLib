using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookLib.Domain.Entities
{
    public class UserFavs
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid BookId { get; set; }
    }
}
