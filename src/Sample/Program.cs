using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sample.Infrastructures;
using Sample.Interfaces.Commands;
using Sample.Interfaces.Queries;
using Sample.Interfaces.Repositories;
using Sample.Models;
using Sample.Services.User.Commands;
using Sample.Services.User.Queries;

namespace Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // Worker
                    services.AddHostedService<Worker>();

                    // Register Services
                    services.Scan(s =>
                    {
                        s.FromEntryAssembly()
                        .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                        .AsSelfWithInterfaces().WithTransientLifetime()
                        .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                        .AsSelfWithInterfaces().WithTransientLifetime();

                        s.FromEntryAssembly()
                        .AddClasses(c => c.Where(w => w.Name.EndsWith("Repository")))
                        .AsSelfWithInterfaces().WithSingletonLifetime();
                    });

                    // Decorator
                    services.Decorate(typeof(ICreateUserCommandHandler), typeof(CreateUserCommandDecorator));
                    services.Decorate(typeof(IUserRepository), typeof(CacheUserRepository));

                    // Mapping
                    services.AddAutoMapper(cfg =>
                    {
                        cfg.CreateMap<GetUserByIdResponse, User>()
                            .ConstructUsing(c => User.Create(c.AbsolutelyUserId, c.MaybeUserName));
                    }, typeof(Program).Assembly);
                });
    }
}
