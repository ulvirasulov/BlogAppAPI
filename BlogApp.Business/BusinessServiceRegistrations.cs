using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Business.Services.Implementations;
using BlogApp.Business.Services.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Business
{
    public static class BusinessServiceRegistrations
    {
        public static void AddBusinessService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BusinessServiceRegistrations));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
