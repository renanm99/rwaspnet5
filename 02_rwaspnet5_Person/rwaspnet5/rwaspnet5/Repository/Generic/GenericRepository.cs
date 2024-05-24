using Microsoft.EntityFrameworkCore;
using rwaspnet5.Model;
using rwaspnet5.Model.Base;
using rwaspnet5.Model.Context;
using System;

namespace rwaspnet5.Repository.Generic
{
    public class GenericRepository<Base> : IRepository<Base> where Base : BaseEntity
    {
        private SQLContext _context;
        private DbSet<Base> _dbSet;

        public GenericRepository(SQLContext context)
        {
            _context = context;
            _dbSet = _context.Set<Base>();
        }
        public Base Create(Base item)
        {
            try
            {
                _dbSet.Add(item);
                //_context.Add(person);
                _context.SaveChanges();
                return item;
            }
            catch (Exception) { throw; }
        }

        public Base FindByID(long id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public List<Base> FindAll()
        {
            return _dbSet.OrderByDescending(x => x.Id).ToList();
        }

        public Base Update(Base item)
        {
            if (!Exists(item.Id)) return null;

            var result = _dbSet.SingleOrDefault(x => x.Id == item.Id);

            if (result != null)
            {
                try
                {
                    _dbSet.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();

                    return item;
                }
                catch (Exception) { throw; }


            }
            else { return null; }
        }

        public void Delete(long id)
        {
            var result = _dbSet.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                try
                {
                    _dbSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception) { throw; }
            }
        }

        public bool Exists(long id)
        {
            return _dbSet.Any(x => x.Id == id);
        }
    }
}
