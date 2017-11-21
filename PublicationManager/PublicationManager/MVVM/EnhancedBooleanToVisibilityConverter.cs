using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PublicationManager.MVVM
{
    public class EnhancedBooleanToVisibilityConverter : IValueConverter
    {
        public enum ConversionMode
        {
            Normal,
            Reverse
        }

        public ConversionMode Mode { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                var boolValue = (bool) value;
                if (Mode == ConversionMode.Reverse)
                {
                    boolValue = !boolValue;
                }

                if (boolValue)
                {
                    return Visibility.Visible;
                }
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
