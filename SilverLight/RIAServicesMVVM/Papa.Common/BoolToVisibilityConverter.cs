using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Papa.Common  
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }
            
            if (parameter.ToString() == "Inverse")
            {
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}