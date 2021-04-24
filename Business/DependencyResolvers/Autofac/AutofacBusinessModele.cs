using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract.Services;
using Business.Concrete.Managers;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract.Dals;
using DataAccess.Concrete.EFDals;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModele : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region readme
            // IoC container karsiligi
            // Farkli bir API kullanmak istendiğinde kod tekrarına düşmemek için Business layerda kullanılır.
            // Bu modulu oluşturulduktan sonra API program.cs de 
            /*
                public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
             */
            // kodunu ekleyiniz.
            #endregion

            #region Default
            builder.RegisterType<DefaultManager>().As<IDefaultService>().SingleInstance();
            builder.RegisterType<EfDefaultDal>().As<IDefaultDal>().SingleInstance();
            #endregion

            #region User
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            #endregion

            #region Auth
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            #endregion

            #region Core.Aspect
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
            #endregion
        }
    }
}
