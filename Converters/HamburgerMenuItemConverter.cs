using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using ETFHelper_WPF.Models;
using MahApps.Metro.Controls;

namespace ETFHelper_WPF.Converters
{
    public class HamburgerMenuItemConverter : IValueConverter
    {
        #region მეთოდები

        public object Convert(object  value, Type targetType, object  parameter, CultureInfo culture)
        {
            if (value is  IEnumerable<IMenuItem>  nmItemCollection)
            {
                return nmItemCollection.Select(item => new HamburgerMenuIconItem
                {
                    Tag = item, 
                    Label = item.Title, 
                    Icon = item.Icon
                });
            }

            return value; 
        }

        public object ConvertBack(object  value, Type  targetType, object  parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class SelectedItemConverter : IValueConverter
    {
        #region მეთოდები

        public object  Convert(object  value, Type  targetType, object parameter, CultureInfo culture)
        {
            return value is HamburgerMenuIconItem menuItem ? menuItem.Tag : value;
        }

        public object ConvertBack(object  value, Type  targetType, object  parameter, CultureInfo culture)
        {
            return value is HamburgerMenuIconItem menuItem ? menuItem.Tag : value;
        }

        #endregion
    }
}
