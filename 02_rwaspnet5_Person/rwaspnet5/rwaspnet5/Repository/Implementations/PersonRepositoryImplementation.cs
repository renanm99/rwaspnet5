using Azure.Core;
using Microsoft.EntityFrameworkCore;
using rwaspnet5.Model;
using rwaspnet5.Model.Context;

namespace rwaspnet5.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private SQLContext _context;

        public PersonRepositoryImplementation(SQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.OrderByDescending(x => x.Id).ToList();
        }

        public Person FindByID(long id)
        {
            return _context.Persons.SingleOrDefault(x => x.Id == id);
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Persons.Add(person);
                //_context.Add(person);
                _context.SaveChanges();

            }
            catch (Exception) { throw; }

            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;

            var result = _context.Persons.SingleOrDefault(x => x.Id == person.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();

                    return person;
                }
                catch (Exception) { throw; }


            }

            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception) { throw; }
            }
        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(x => x.Id == id);
        }
    }
}
