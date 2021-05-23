using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

using Balancer.Model;

namespace Balancer.Converters
{
    public class UnityColorToSystemColorConverter : MarkupExtension, IValueConverter
    {
        public override Object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (value is UnityColor customColor)
            {
                var alpha = (byte)Math.Floor(customColor.A >= 1.0 ? 255 : customColor.A * 256.0);

                var red = (Byte)Math.Round(customColor.R * 255);
                var green = (Byte)Math.Round(customColor.G * 255);
                var blue = (Byte)Math.Round(customColor.B * 255);


                var systemColor = System.Windows.Media.Color.FromArgb(alpha, red, green, blue);

                return systemColor;
            }

            return Binding.DoNothing;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (value is System.Windows.Media.Color mediaColor)
            {
                return new UnityColor(mediaColor.ScA, mediaColor.ScR, mediaColor.ScG, mediaColor.ScB);
            }

            return Binding.DoNothing;
        }
    }
}
