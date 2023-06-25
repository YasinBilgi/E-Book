using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public partial class BookCategory
    {
        public int Id { get; set; }

        public int? BookId { get; set; }
        public Book? Book { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
