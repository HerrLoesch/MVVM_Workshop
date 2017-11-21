using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommonServiceLocator;

namespace PublicationManager.Infrastructure
{
    public static class ViewModelLocator
    {
        public static DependencyProperty RegisterViewModelProperty = DependencyProperty.RegisterAttached("RegisterViewModel", typeof(bool), typeof(ViewModelLocator), new PropertyMetadata(false, RegisterViewModelChanged));

        public static bool GetRegisterViewModel(DependencyObject obj)
        {
            return (bool)obj.GetValue(RegisterViewModelProperty);
        }

        public static void SetRegisterViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(RegisterViewModelProperty, value);
        }

        private static void RegisterViewModelChanged(DependencyObject view, DependencyPropertyChangedEventArgs e)
        {
            if (!DesignerProperties.GetIsInDesignMode(view))
            {
                if ((bool)e.NewValue)
                {
                    var viewType = view.GetType();
                    var viewModelType = GetViewModelType(viewType);

                    var viewModel = ServiceLocator.Current.GetInstance(viewModelType);
                    Bind(view, viewModel);
                }
            }
        }

        static void Bind(object view, object viewModel)
        {
            FrameworkElement element = view as FrameworkElement;
            if (element != null)
                element.DataContext = viewModel;
        }

        private static Type GetViewModelType(Type viewType)
        {
            var viewName = viewType.FullName;
            viewName = viewName.Replace(".Views.", ".ViewModels.");

            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;

            var suffix = viewName.EndsWith("View") ? "Model" : "ViewModel";

            var viewModelName = String.Format(CultureInfo.InvariantCulture, "{0}{1}, {2}", viewName, suffix,
                viewAssemblyName);

            return Type.GetType(viewModelName);
        }
    }
}
