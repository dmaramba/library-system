using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public interface IBookService
    {
        public int AddBook(Book book);
        public Book GetBook(int Id);
        public List<Book> GetBooks();

        public void  SetAvailability(int Id, bool status);
    }
}
