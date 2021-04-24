using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Business.DependencyResolvers.Autofac;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //--> Servisa saglayici olarak Autofac servis saglayiciyi kullanacak.
            .ConfigureContainer<ContainerBuilder>(builder =>                //--> Autofac servis saglayicisi icin business katmaninda yazdigimiz modulu configre et.
            {
                builder.RegisterModule(new AutofacBusinessModele());
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
