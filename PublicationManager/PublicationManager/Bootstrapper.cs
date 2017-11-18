using System.Reflection;
using System.Windows;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using PublicationManager.Views;

namespace PublicationManager
{
    public class Bootstrapper
    {
        public void Run()
        {
            var iocContainer = CreateIocContainerWithRegisteredTypes();
            var window = CreateShell(iocContainer);
            ShowWindow(window);
        }

        private static IContainer CreateIocContainerWithRegisteredTypes()
        {
            var containerBuilder = new ContainerBuilder();

            // Be carefull in large projects! This will register all and I mean ALL types!!!
            // In this case it is not a big deal but it can heavily influence the performance in large applications.
            containerBuilder.RegisterAssemblyTypes(Assembly.GetCallingAssembly());
            containerBuilder.RegisterAssemblyTypes(Assembly.GetCallingAssembly()).AsImplementedInterfaces();

            var container = containerBuilder.Build();
            
            // I cases we need the service locator, we use a common interface.
            var autofacServiceLocator = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => autofacServiceLocator);

            return container;
        }

        private static Window CreateShell(IContainer iocContainer)
        {
            return iocContainer.Resolve<MainWindow>();
        }

        private void ShowWindow(Window window)
        {
            Application.Current.MainWindow = window;
            window.Show();
        }
    }
}
