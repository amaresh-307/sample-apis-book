using Ajmera_Assignment.Controllers;
using AutoMapper;
using Books.Abstraction;
using Books.Abstraction.APIModels;
using Books.DAL.Context;
using Books.DAL.Repositories;
using Books.DAL.Services;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace Book.Tests
{
    public class BookServiceTest
    {
        private readonly Mock<IMapper> mapper = new Mock<IMapper>();
        private readonly Mock<ILogger<BookRepository>> logger = new Mock<ILogger<BookRepository>>();
        private readonly IBookService bookService;
        private readonly IBookRepository bookRepo;
        private readonly Mock<BookDbContext> bookContext = new Mock<BookDbContext>();
        public BookServiceTest()
        {
            bookRepo = new BookRepository(logger.Object, bookContext.Object);
            bookService = new BookService(mapper.Object, bookRepo);
        }

        //Test fails
        [Fact]
        public async Task GetById_Fail()
        {
            var bookId = Guid.NewGuid();

            var book = await bookService.GetBookById(bookId);

            Assert.Equal(bookId, book.Id);
        }

        //Test passes
        [Fact]
        public async Task GetById_Pass()
        {
            var bookId = new Guid("bed195e0-cf6a-4e9d-86d1-c65d4063b82f");

            var book = await bookService.GetBookById(bookId);

            Assert.Equal(bookId, book.Id);
        }

        [Fact]
        public async Task GetAllBook()
        {
            var books = await bookService.GetAllBooks();

            Assert.Equal(books, Enumerable.Empty<BookViewModel>());
        }
    }
}
