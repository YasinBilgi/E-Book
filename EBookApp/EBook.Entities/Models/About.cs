using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public class About
    {
        [Key]

        public int Id { get; set; }

        public string Title { get; set; }

        public string? İmageUrl { get; set; }

        public string Subtitle { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
