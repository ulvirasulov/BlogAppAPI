using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Core.Entities.Common;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        BlogAppDbContext _context;

        public Repository(BlogAppDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<TEntity> Create(TEntity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression)
        {
            return Table.Where(expression);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Table;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<bool> IsExsist(Expression<Func<TEntity, bool>> expression)
        {
            return await Table.AnyAsync(expression);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            Table.Update(entity);
        }        

    }
}
