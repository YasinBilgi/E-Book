using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public partial class BookFavorite
    {
        public int Id { get; set; }

        public int? BookId { get; set; }
        public Book? Book { get; set; }

        public int? FavoriteId { get; set; }
        public Favorite? Favorite { get; set; }
    }
}
