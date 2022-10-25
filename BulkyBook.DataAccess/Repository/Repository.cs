using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{

    //implementing genaric repository
    public class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext _db;
        internal DbSet<T> Dbset;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.Dbset = _db.Set<T>();
           // _db.Products.Include(u=>u.Category).Include(u=>u.CoverType);
        
        }
        public void Add(T entity)
        {
            Dbset.Add(entity);
            //  _db.Categories.Add(entity);   same like what I did in controller menu.....
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = Dbset;
            if (includeProperties!=null)
                {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                    query=query = query.Include(includeProp);   
                    }
                }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {

            IQueryable<T> query = Dbset;
            if (includeProperties != null)
                {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                    query = query = query.Include(includeProp);
                    }
                }
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            Dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            Dbset.RemoveRange(entity);
        }
    }
}
