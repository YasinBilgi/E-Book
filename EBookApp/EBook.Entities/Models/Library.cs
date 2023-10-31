using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public class Library
    {
        public Library()
        {
            Books = new HashSet<Book>();
        }

        [Key]

        public int Id { get; set; }

        [MaxLength(50)]
        public string LibraryName { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
