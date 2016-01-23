using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq.Expressions;

namespace MyApplication.DAL
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private ApplicationDbContext context;

        private IDbSet<TEntity> Dbset
        {
            get { return context.Set<TEntity>(); }
        }

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> @where)
        {
            return Dbset.FirstOrDefault(where);
        }

        public IEnumerable<TEntity> GetAll()
        {
            var result = this.Dbset.ToList();
            return result;
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> @where, int take = 0)
        {
            return take <= 0 ? Dbset.Where(where).ToList() : Dbset.Where(where).Take(take).ToList();
        }

        public void Insert(TEntity entity)
        {
            Dbset.Add(entity);
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}