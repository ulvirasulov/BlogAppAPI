using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        public DbSet<TEntity> Table { get; }
        public Task<TEntity> GetById(int id);
        public IQueryable<TEntity> GetAll();
        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression);
        public Task<TEntity> Create(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public Task<int> SaveChangesAsync();
        public Task<bool> IsExsist(Expression<Func<TEntity, bool>> expression);
    }
}
