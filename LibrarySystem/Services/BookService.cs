using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDBContext _context;
        public BookService(LibraryDBContext context)
        {
            this._context = context;
        }

        public int AddBook(Book book)
        {
            _context.Books.Add(book);
            return book.Id;
        }

        public Book GetBook(int Id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == Id);
            return book!;
        }

        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public void SetAvailability(int Id, bool status)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == Id);
            if (book != null)
            {
                book.IsAvailable = status;
                _context.SaveChanges();
            }
        }
    }
}
