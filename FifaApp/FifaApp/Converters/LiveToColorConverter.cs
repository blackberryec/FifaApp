using System;
using System.Globalization;
using Xamarin.Forms;

namespace FifaApp.Converters
{
    public class LiveToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool bValue && bValue)
            {
                return Color.GreenYellow;
            }

            return Color.LightGray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}