using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Models
{
    public class LibraryDBContext : IdentityDbContext<ApplicationUser>
    {

        public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options) { }

        public required DbSet<Book> Books { get; set; }
        public required DbSet<Customer> Customers { get; set; }
        public required DbSet<BorrowBook> BorrowBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasKey(x => x.Id);
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);
            modelBuilder.Entity<BorrowBook>().HasKey(x => x.Id);
        }
    }
}
