using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Data
{
    public static class BookSeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<LibraryDBContext>();
            await db.Database.EnsureCreatedAsync();

            if (!await db.Books.AnyAsync())
            {

                await db.Books.AddRangeAsync(
                    new Book
                    {
                        Title = "Clean Code",
                        Author = "Robert C. Martin",
                        Year = 2008,
                        Total = 5,
                        IsDeleted = false,
                        IsAvailable = true,
                        Created = DateTime.Now
                    },
                    new Book
                    {
                        Title = "The Pragmatic Programmer",
                        Author = "Andrew Hunt, David Thomas",
                        Year = 1999,
                        Total = 3,
                        IsDeleted = false,
                        IsAvailable = true,
                        Created = DateTime.Now
                    }
                );

                await db.SaveChangesAsync();
            }
        }
    }
}
