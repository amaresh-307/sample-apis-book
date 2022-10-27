using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Abstraction.APIModels
{
    public class AddBookModel
    {
        public string Name { get; set; }
        public string AuthorName { get; set; }
    }
}
