using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public class Contact
    {
        [Key]

        public int Id { get; set; }

        [MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Subtitle { get; set; }

        [MaxLength(300)]
        public string? Address { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(10)]
        public string Phone { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
