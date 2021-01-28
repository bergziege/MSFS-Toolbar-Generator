using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace De.Berndnet2000.MsfsToolbarGenerator.UI.Converter {
    public class BooleanToVisibilityCollapsedConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value is bool boolValue ? boolValue ? Visibility.Visible : Visibility.Collapsed : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}