using Books.Abstraction;
using Books.Abstraction.Entities;
using Books.DAL.Context;
using Microsoft.Extensions.Logging;

namespace Books.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;
        private readonly ILogger<BookRepository> _logger;
        public BookRepository(ILogger<BookRepository> logger, BookDbContext context)
        {
            _logger = logger; 
            _context = context;
        }
        public async Task AddBook(Book book)
        {
            try
            {
                _logger.LogInformation("Adding book to DB");
                 await _context.Book.AddAsync(book);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Book added to DB successfully");
            }
            catch(Exception ex)
            {
                _logger.LogError("Book could not be added.", ex);
                throw;
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            try
            {
                _logger.LogInformation("Fetching books from DB");
                return _context.Book.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Book could not be added.", ex);
                throw;
            }
        }

        public async Task<Book> GetBookById(Guid id)
        {
            try
            {
                _logger.LogInformation("Fetching Book from DB");
                return _context.Book.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError("Book could not be added.", ex);
                throw;
            }
        }
    }
}
