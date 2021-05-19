using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Balancer.Converters
{
    public class ValueIsDefaultToBooleanConverter : MarkupExtension, IValueConverter
    {
        public override Object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            var isDefaultValue = false;

            

            return isDefaultValue;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
