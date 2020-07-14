using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Data.Context;
using System.Data.Entity;

namespace QaisYousuf.Data.Concrete_Implementation
{

    public abstract class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected UIContext _context;
        public Repository(UIContext context)
        {
            _context = context;
        }

        public void Add(TModel entity)
        {
            _context.Set<TModel>().Add(entity);
        }

        public IQueryable<TModel> GetAll()
        {
            IQueryable<TModel> data = _context.Set<TModel>().AsQueryable();
            return data;
        }

        public IQueryable<TModel> GetAll(params string[] navigationProperties)
        {
            IQueryable<TModel> data = _context.Set<TModel>().AsQueryable();

            foreach(string navigationproperty in navigationProperties)
            {
                data = data.Include(navigationproperty);
            }

            return data;
        }

        public TModel GetById(object id)
        {
            return _context.Set<TModel>().Find(id);
        }

        public void Remove(TModel entity)
        {
            _context.Set<TModel>().Remove(entity);
        }

        public void RemoveById(object id)
        {
            TModel model = GetById(id);
            if (model != null)
                Remove(model);
        }

        public void Update(TModel entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
