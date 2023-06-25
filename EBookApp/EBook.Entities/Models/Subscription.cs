using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public class Subscription
    {
        [Key]

        public int Id { get; set; }

        [MaxLength(150)]
        public string SubscriptionName { get; set; }

        [MaxLength(050)]
        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }


        public int? UserId { get; set; }
        public virtual User User { get; set; } = null!;


        public int? PaymentId { get; set; }
        public virtual Payment Payment { get; set; } = null!;
    }
}
