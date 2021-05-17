using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

using Balancer.Base;

namespace Balancer.Converters
{
    public class ResourceNameToImageSourceConverter : MarkupExtension, IValueConverter
    {
        public Boolean IsLoadingUsingKey { get; set; }
        public String ResourceKeyBase { get; set; }

        public override Object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (value is String stringValue)
            {
                var resources = Resources.GetResources(stringValue);

                var resourceCount = resources.Count();

                if (resourceCount == 1)
                {
                    var resource = resources.First();

                    if (resource.ResourceType == Model.Resources.ResourceType.Image)
                    {
                        return resource.ToImageSource();
                    }
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
