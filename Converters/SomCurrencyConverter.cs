using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnApropos.Converters
{
    public class SomCurrencyConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            if (value is not double currency)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return $"{currency} сом";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            if (value is not string currency)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var spaceIndex = currency.IndexOf(" ");
            var parsed = string.Empty;

            if(spaceIndex >= 0)
            {
                parsed = currency.Remove(spaceIndex, currency.Length - spaceIndex);
            }
            else
            {
                parsed = currency;
            }

            try
            {
                return double.Parse(parsed);
            }
            catch
            {
                throw new InvalidCastException("Bad format");
            }
            
        }
    }
}
