using AutoMapper;
using Books.Abstraction;
using Books.Abstraction.APIModels;
using Books.Abstraction.Entities;

namespace Books.DAL.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _repo;
        public BookService(IMapper mapper, IBookRepository repository)
        {
            _mapper = mapper;
            _repo = repository;
        }
        public async Task<Guid> AddBook(AddBookModel addBookModel)
        {
            try
            {
                var book = this._mapper.Map<Book>(addBookModel);
                book.Id = Guid.NewGuid();
                await _repo.AddBook(book);
                return book.Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<BookViewModel>> GetAllBooks()
        {
            try
            {
                var allBooks = await _repo.GetAllBooks();
                return _mapper.Map<IEnumerable<BookViewModel>>(allBooks);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<BookViewModel> GetBookById(Guid id)
        {
            try
            {
                var aBook = await _repo.GetBookById(id);
                return _mapper.Map<BookViewModel>(aBook);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
