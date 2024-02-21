using Accredit.Challenge.Borders.Repositories;
using Accredit.Challenge.Borders.Services;
using Accredit.Challenge.Repositories.HttpClients;
using Accredit.Challenge.Repositories.Repositories;
using Accredit.Challenge.Services.Services;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Web.Mvc;

namespace Accredit.Challenge.Api.Configurations
{
    public static class IocConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<GithubService>().As<IGithubService>();
            builder.RegisterType<GithubRepository>().As<IGithubRepository>();
            builder.RegisterType<GithubHttpClient>();
            builder.RegisterType<HttpClient>();
            builder.RegisterGeneric(typeof(OptionsManager<>)).As(typeof(IOptions<>)).SingleInstance();
            builder.RegisterGeneric(typeof(OptionsManager<>)).As(typeof(IOptionsSnapshot<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(OptionsMonitor<>)).As(typeof(IOptionsMonitor<>)).SingleInstance();
            builder.RegisterGeneric(typeof(OptionsFactory<>)).As(typeof(IOptionsFactory<>));
            builder.RegisterGeneric(typeof(OptionsCache<>)).As(typeof(IOptionsMonitorCache<>)).SingleInstance();
            builder.RegisterType<MemoryCache>().As<IMemoryCache>().SingleInstance();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }


    }
}