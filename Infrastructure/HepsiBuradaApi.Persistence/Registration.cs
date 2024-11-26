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
            
        }
    }
}
