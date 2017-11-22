using System;
using System.Reflection;
using System.Windows;
using Autofac;
using Autofac.Builder;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using PublicationManager.Interfaces;
using PublicationManager.Services;
using PublicationManager.ViewModels;
using PublicationManager.Views;

namespace PublicationManager.Infrastructure
{
    public static class ViewNames
    {
        public static string PublicationView = "PublicationView";
        public static string MediumView = "MediumView";
    }

    public class Bootstrapper
    {
        public void Run()
        {
            var container = ConfigureIoCContainer();
            RegisterViews(container);
            var mainWindow = ConfigureMainWindow(container);
            ShowMainWindow(mainWindow);
        }

        private static void RegisterViews(IContainer container)
        {
            var navigationService = (NavigationManager)container.Resolve<INavigationManager>();
            navigationService.RegisterView(ViewNames.PublicationView, typeof(PublicationView));
            navigationService.RegisterView(ViewNames.MediumView, typeof(MediumView));
        }

        private static void ShowMainWindow(Window mainWindow)
        {
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }

        private static Window ConfigureMainWindow(IContainer container)
        {
            return container.Resolve<MainWindow>();
        }

        private static IContainer ConfigureIoCContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetCallingAssembly()).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.GetCallingAssembly()).AsSelf();

            builder.RegisterType<NavigationManager>().As<INavigationManager>().SingleInstance();

            var container = builder.Build();

            // I cases we need the service locator, we use a common interface.
            var autofacServiceLocator = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => autofacServiceLocator);


            return container;
        }
    }
}
