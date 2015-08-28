using Playground.EF.App.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace Playground.EF.App.Repositories
{
    public class Repository<T> where T : class
    {
        private DataContext _context = null;

        public string ConnectionString
        {
            get { return this._context.Database.Connection.ConnectionString; }
        }

        protected DbSet<T> DbSet { get; set; }

        public Repository()
        {
            this._context = new DataContext();
            this.DbSet = _context.Set<T>();
        }

        public Repository(DataContext context)
        {
            _context = context;
        }

        public virtual List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual T Get(Guid uid)
        {
            return DbSet.Find(uid);
        }

        public void Add(T instance)
        {
            DbSet.Add(instance);
        }

        public virtual void Update(T instance)
        {
            _context.Entry<T>(instance).State = EntityState.Modified;
        }

        public virtual List<DbValidationError> SaveChanges()
        {
            List<DbValidationError> result = new List<DbValidationError>();
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                ex.EntityValidationErrors.ToList()
                    .ForEach(r =>
                        r.ValidationErrors.ToList()
                        .ForEach(ve =>
                            result.Add(ve)
                        )
                    );
            }
            catch (DbUpdateConcurrencyException)
            {
                result.Add(
                    new DbValidationError(
                        "",
                        "The entity passed is out of date, please refresh the screen to get the latest version and try again"
                    )
                );
            }

            return result;
        }
    }
}