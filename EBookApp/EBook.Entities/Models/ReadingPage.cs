using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public class ReadingPage
    {
        [Key]

        public int Id { get; set; }

        [MaxLength(150)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string BookName { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }


        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        public int? BookId { get; set; }
        public virtual Book? Book { get; set; }
    }
}
