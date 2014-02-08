namespace JulianPerrottName.App_Start
{
    using System.Web.Mvc;
    using JulianPerrottName.Repository;
    using Microsoft.Practices.Unity;
    using Unity.Mvc4;

    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IBlogRepository, Repository>();
            container.RegisterType<IFeedReader, Repository>();
            container.RegisterType<IPageRepository, Repository>();

            return container;
        }
    }
}