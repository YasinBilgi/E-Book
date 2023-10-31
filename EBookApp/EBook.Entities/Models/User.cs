using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public class User
    {
        public User()
        {
            Messages = new HashSet<Message>();
            Books = new HashSet<Book>();
            ReadingPages = new HashSet<ReadingPage>();
            Payments = new HashSet<Payment>();
            Favorites = new HashSet<Favorite>();
            Cards = new HashSet<Card>();
            SubscriptionHistories = new HashSet<SubscriptionHistory>();
        }

        [Key]

        public int Id { get; set; }

        public string? Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Library? Library { get; set; }
        public virtual Subscription? Subscription { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<ReadingPage> ReadingPages { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<SubscriptionHistory> SubscriptionHistories { get; set; }
    }
}
