using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PublicationManager.MVVM
{
    public class ExtendedBooleanToVisibilityConverter : IValueConverter
    {
        public ConversionMode Mode { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility result = Visibility.Collapsed;

            if (value is bool b)
            {
                result = b ? Visibility.Visible : Visibility.Collapsed;

                if (this.Mode == ConversionMode.Inverse)
                {
                    result = result == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                }
            }
            
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Don't try this at home. Always fill out your ConvertBack methods...
            throw new NotImplementedException();
        }

        public enum ConversionMode
        {
            Normal,
            Inverse
        }
    }
}