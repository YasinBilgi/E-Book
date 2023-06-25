using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public class Card
    {
        [Key]

        public int Id { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string FullName { get; set; }

        [MaxLength(16)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string CardNumber { get; set; }

        [MaxLength(4)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public DateTime ExpiryDate { get; set; }

        [MaxLength(4)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string CVV { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }


        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        public int? PaymentId { get; set; }
        public virtual Payment Payment { get; set; } = null!;
    }
}
