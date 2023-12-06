using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public class Category
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }


        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}
