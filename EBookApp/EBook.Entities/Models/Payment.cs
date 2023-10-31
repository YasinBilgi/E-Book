using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public class Payment
    {
        [Key]

        public int Id { get; set; }

        public string? DocummentUrl { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }


        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual Card? Card { get; set; }
        public virtual Subscription? Subscription { get; set; }
    }
}
