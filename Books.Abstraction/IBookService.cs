using Books.Abstraction.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Abstraction
{
    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetAllBooks();
        Task<BookViewModel> GetBookById(Guid id);
        Task<Guid> AddBook(AddBookModel addBookModel);
    }
}
