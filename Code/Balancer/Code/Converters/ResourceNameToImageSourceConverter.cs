using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

using Balancer.Base;

namespace Balancer.Converters
{
    public class ResourceNameToImageSourceConverter : MarkupExtension, IValueConverter
    {
        public override Object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (value is String stringValue)
            {
                var resources = Resources.GetResources(stringValue);

                if (resources.Count == 1)
                {
                }
                else if (resources.Count > 1)
                {

                }
            }

            return Binding.DoNothing;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
