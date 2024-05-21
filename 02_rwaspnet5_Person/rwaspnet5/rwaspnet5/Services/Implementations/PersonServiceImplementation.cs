﻿using Azure.Core;
using Microsoft.EntityFrameworkCore;
using rwaspnet5.Model;
using rwaspnet5.Model.Context;

namespace rwaspnet5.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private SQLContext _context;

        public PersonServiceImplementation(SQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindByID(long id)
        {
            return _context.Persons.SingleOrDefault(x => x.Id == id);
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();

            }
            catch (Exception) { throw; }

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

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

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

        private bool Exists(long id)
        {
            return _context.Persons.Any(x => x.Id == id);
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Person Name" + i,
                LastName = "Person Lastname" + i,
                Address = "Some Address" + i,
                Gender = "Male"
            };
        }
    }
}
