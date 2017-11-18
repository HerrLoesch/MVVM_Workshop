using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows;
using CommonServiceLocator;

/*
 * This code is mainly based on the ideas behind https://github.com/PrismLibrary/Prism/blob/master/Source/Wpf/Prism.Wpf/Mvvm/ViewModelLocator.cs
 * and https://github.com/PrismLibrary/Prism/blob/master/Source/Prism/Mvvm/ViewModelLocationProvider.cs
 */
namespace PublicationManager.MVVM
{
    public static class ViewModelLocator
    {
        public static DependencyProperty AutoWireViewModelProperty =
            DependencyProperty.RegisterAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator),
                new PropertyMetadata(false, AutoWireViewModelChanged));

        public static bool GetAutoWireViewModel(DependencyObject obj)
        {
            return (bool) obj.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoWireViewModelProperty, value);
        }

        private static void AutoWireViewModelChanged(DependencyObject view, DependencyPropertyChangedEventArgs e)
        {
            if (!DesignerProperties.GetIsInDesignMode(view))
            {
                if ((bool) e.NewValue)
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