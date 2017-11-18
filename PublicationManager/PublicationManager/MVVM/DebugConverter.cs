using System;
using System.Globalization;
using System.Windows.Data;

namespace PublicationManager.MVVM
{
    public class DebugConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine($"Get value \"{value}\" for type \"{targetType}\" during convert.");
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine($@"Get value ""{value}"" for type ""{targetType}"" during convert back.");
            return value;
        }
    }
}
