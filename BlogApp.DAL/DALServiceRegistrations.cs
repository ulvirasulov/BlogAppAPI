using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.DAL.Repositories.Implementations;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.DAL
{
    public static class DALServiceRegistrations
    {
        public static void AddDALService(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
