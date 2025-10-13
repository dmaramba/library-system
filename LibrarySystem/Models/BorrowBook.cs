using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class BorrowBook
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned {  get; set; }

    }
}
