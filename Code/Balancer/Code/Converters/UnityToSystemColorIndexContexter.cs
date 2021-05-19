using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Balancer.Converters
{
    public class UnityToSystemColorIndexContexter : MarkupExtension, IValueConverter
    {
        public override Object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (float.TryParse(value?.ToString(), out float floatValue))
            {
                return floatValue * 255;
            }

            return Binding.DoNothing;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (float.TryParse(value?.ToString(), out float floatValue))
            {
                return floatValue / 255;
            }

            return Binding.DoNothing;
        }
    }
}
