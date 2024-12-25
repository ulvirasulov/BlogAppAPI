using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Core.Entities;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories.Interfaces;

namespace BlogApp.DAL.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogAppDbContext context) : base(context) { }        
    }
}
