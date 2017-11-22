using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CommonServiceLocator;
using PublicationManager.Interfaces;

namespace PublicationManager.Services
{
    public class NavigationManager : INavigationManager
    {
        public static ContentControl contentRegion;

        public static DependencyProperty UseAsContentRegionProperty = DependencyProperty.RegisterAttached("UseAsContentRegion", typeof(bool), typeof(NavigationManager), new PropertyMetadata(false, RegisterContentRegion));

        public static bool GetUseAsContentRegion(DependencyObject obj)
        {
            return (bool) obj.GetValue(UseAsContentRegionProperty);
        }

        public static void SetUseAsContentRegion(DependencyObject obj, bool value)
        {
            obj.SetValue(UseAsContentRegionProperty, value);
        }

        private static void RegisterContentRegion(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            contentRegion = (ContentControl) d;
        }

        Dictionary<string, Type> pageRegistration = new Dictionary<string, Type>();

        public void RegisterView(string pageName, Type pageType)
        {
            pageRegistration.Add(pageName, pageType);
        }

        public void NavigateTo(string pageName)
        {
            var type = pageRegistration[pageName];
            var view = ServiceLocator.Current.GetInstance(type);
            contentRegion.Content = view;
        }
    }
}
