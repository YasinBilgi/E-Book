using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Entities.Models
{
    public partial class EBookDbContext : DbContext
    {
        public EBookDbContext()
        {

        }

        public EBookDbContext(DbContextOptions<EBookDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookDetail> BookDetails { get; set; } = null!;
        public virtual DbSet<Card> Cards { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Library> Libraries { get; set; } = null!;
        public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;
        public virtual DbSet<SubscriptionHistory> SubscriptionHistories { get; set; } = null!;
        public virtual DbSet<ReadingPage> ReadingPages { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Favorite> Favorites { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<About> Abouts { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<MainPage> MainPages { get; set; } = null!;
        public virtual DbSet<BookAuthor> BookAuthors { get; set; } = null!;
        public virtual DbSet<BookCategory> BookCategories { get; set; } = null!;
        public virtual DbSet<BookFavorite> BookFavorites { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"Data source=.\SQLEXPRESS;" +
                            "Initial Catalog=EBookDb;Integrated Security=true;" +
                            "TrustServerCertificate=true;",
                    providerOptions => { providerOptions.EnableRetryOnFailure(); });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>(entity =>
            {
                entity.ToTable("About");

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.İmageUrl)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Subtitle)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .IsFixedLength();

                entity.Property(e => e.CreatedDate)
                    .IsFixedLength();

            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.Subtitle)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .HasMaxLength(300)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .IsFixedLength();

                entity.Property(e => e.CreatedDate)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MainPage>(entity =>
            {
                entity.ToTable("MainPage");

                entity.Property(e => e.Title)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .IsFixedLength();

                entity.Property(e => e.CreatedDate)
                    .IsFixedLength();
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
