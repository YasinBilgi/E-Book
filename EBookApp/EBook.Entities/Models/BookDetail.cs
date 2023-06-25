using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public class BookDetail
    {
        [Key]

        public int Id { get; set; }

        [MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public int Stock { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? BookId { get; set; }
        public virtual Book Book { get; set; } = null!;
    }
}
