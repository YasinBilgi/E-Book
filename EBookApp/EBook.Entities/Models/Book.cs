using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public class Book
    {
        public Book()
        {
            ReadingPages = new HashSet<ReadingPage>();
        }

        [Key]

        public int Id { get; set; }

        [MaxLength(150)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Name { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string AuthorName { get; set; }

        [MaxLength(1000)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Description { get; set; }

        public int NumberPage { get; set; }

        public string? İmageUrl { get; set; }

        public DateTime PublishDate { get; set; }

        public string Isbn { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }


        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        public int? LibraryId { get; set; }
        public virtual Library? Library { get; set; }


        public virtual BookDetail? BookDetail { get; set; }

        public virtual ICollection<ReadingPage> ReadingPages { get; set; }

        public virtual List<BookAuthor> BookAuthors { get; set; }
        public virtual List<BookCategory> BookCategories { get; set; }
        public virtual List<BookFavorite> BookFavorites { get; set; }
    }
}
