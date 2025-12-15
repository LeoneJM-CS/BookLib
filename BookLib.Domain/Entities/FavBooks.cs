using System;
using System.Collections.Generic;
using System.Text;

namespace BookLib.Domain.Entities
{
    public class FavBooks
    {
        public Guid FavId { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
