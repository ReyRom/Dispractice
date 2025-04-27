using Avalonia.Data.Converters;
using Dispractice.Models;
using System;
using System.Globalization;

namespace Dispractice.Extensions
{
    public class PenaltyTypeConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is PenaltyType type)
            {
                return type.GetDescription();
            }

            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
