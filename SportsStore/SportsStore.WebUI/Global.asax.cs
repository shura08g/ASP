using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using SportsStore.WebUI.Infrastructure;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Binders;
using System.Data.Entity;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI
{
    // Примечание: Инструкции по включению классического режима IIS6 или IIS7 
    // см. по ссылке http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // сообщить MVC, что для создания объектов контроллера
            // мы хотим использовать класс NinjectController.
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            // использовать класс CartModelBinder для создания экземпляров объекта Cart.
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());

            // если ошибка "The model backing the 'EFDbContext' context has changed since the database was created.."
            // включить миграцию
            Database.SetInitializer<EFDbContext>(null);
        }
    }
}