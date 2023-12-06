using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public class Favorite
    {
        [Key]

        public int Id { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }


        public int? UserId { get; set; }
        public virtual User? User { get; set; }


        public virtual ICollection<BookFavorite> BookFavorites { get; set; }
    }
}
