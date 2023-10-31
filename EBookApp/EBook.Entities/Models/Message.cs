using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public class Message
    {
        [Key]

        public int Id { get; set; }

        [MaxLength(150)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string FullName { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Email { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Phone { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Subject { get; set; }

        [MaxLength(500)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }



        public int? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
