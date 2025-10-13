using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year {  get; set; }

        public int Total { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAvailable {  get; set; } // logic happens in background
        public DateTime Created { get; set; }
    }
}
