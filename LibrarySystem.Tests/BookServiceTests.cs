using LibrarySystem.Models;
using LibrarySystem.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Tests
{
    public class BookServiceTests
    {
        private Mock<IBookService> _bookServiceMock;
        public BookServiceTests()
        {
            _bookServiceMock = new Mock<IBookService>();
        }

        [Fact]
        public void GetBooks_Return_BookList()
        {
            //Arrange
            _bookServiceMock.Setup(x => x.GetBooks()).Returns(new List<Models.Book>
            {
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
            });

            //Act
            var books = _bookServiceMock.Object.GetBooks();

            //Assert

            Assert.NotNull(books);
            Assert.Equal(2, books.Count);

        }

        [Fact]
        public void AddBook_Should_ReturnId_and_Verify_AddBook_Call()
        {
            //Arrange
            _bookServiceMock.Setup(x => x.AddBook(It.IsAny<Book>())).Returns((Book b) => b.Id);
            var book = new Book { Id = 100, Title = "Unit Testing" };

            //Act
            var result = _bookServiceMock.Object.AddBook(book);

            //Assert
            Assert.Equal(100, result);
            _bookServiceMock.Verify(x => x.AddBook(book), Times.Once);

        }

        [Fact]
        public void GetBook_Should_Retunr_Null_If_Not_Found()
        {
            //Arrange
            _bookServiceMock.Setup(x => x.GetBook(It.IsAny<int>())).Returns((Book?)null);
         

            //Act
            var result = _bookServiceMock.Object.GetBook(2000);

            //Assert
            Assert.Null( result);

        }

    }
}
