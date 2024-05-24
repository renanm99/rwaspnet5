using rwaspnet5.Model;
using rwaspnet5.Repository;

namespace rwaspnet5.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Book Create(Book Book)
        {
            return _repository.Create(Book);
        }

        public Book Update(Book Book)
        {

            return _repository.Update(Book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
