using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public class Author
    {
        [Key]

        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime? DeathDate { get; set; }

        public string? Biography { get; set; }

        [MaxLength(256)]
        public string? İmageUrl { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }


        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
