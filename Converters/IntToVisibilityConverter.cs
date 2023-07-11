using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ETFHelper_WPF.Converters;

public class IntToVisibilityConverter : IValueConverter
{
    public object  Convert(object value, Type  targetType, object  parameter, CultureInfo culture)
    {
        var val = (int)value;

        return val != 0 ? Visibility.Visible : Visibility.Collapsed;
    }

    public object  ConvertBack(object value, Type targetType, object parameter, CultureInfo Culture)
    {

        return null;
    }
}
