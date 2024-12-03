using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HepsiBuradaApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using HepsiBuradaApi.Application.Interfaces.Repositories;
using HepsiBuradaApi.Persistence.Repositories;
using HepsiBuradaApi.Application.UnitOfWorks;
using HepsiBuradaApi.Persistence.UnitOfWorks;
using HepsiBuradaApi.Domain.Entities;

namespace HepsiBuradaApi.Persistence
{
    public static class Registration
    {
        public static void AddPersistance(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));


            services.AddScoped<IUnitOfWork, UnitOfwork>();

            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail = false;

            }).AddRoles<Role>().AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
