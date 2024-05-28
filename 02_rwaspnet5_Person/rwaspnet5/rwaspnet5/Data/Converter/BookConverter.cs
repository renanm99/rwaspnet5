using rwaspnet5.Data.Converter.Contract;
using rwaspnet5.Data.VO;
using rwaspnet5.Model;

namespace rwaspnet5.Data.Converter
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null) { return null; }
            return new Book
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                launchDate = origin.launchDate
            };
        }
        public BookVO Parse(Book origin)
        {
            if (origin == null) { return null; }
            return new BookVO
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                launchDate = origin.launchDate
            };
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null) { return null; }
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null) { return null; }
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
