using FluentValidation;
using HepsiBuradaApi.Application.Bases;
using HepsiBuradaApi.Application.Beheviors;
using HepsiBuradaApi.Application.Exceptions;
using HepsiBuradaApi.Application.Features.Products.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;

namespace HepsiBuradaApi.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddRulesFromAsssemblyContaining(assembly, typeof(BaseRules));

            services.AddMediatR(cfg=> cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehavior<,>));
        }

        private static IServiceCollection AddRulesFromAsssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {

            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
               services.AddTransient(item);
                return services;
            

        }
    }
}
