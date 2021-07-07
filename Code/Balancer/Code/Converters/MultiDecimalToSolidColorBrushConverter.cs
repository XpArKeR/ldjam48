using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace Balancer.Converters
{
    public class MultiDecimalToSolidColorBrushConverter : MarkupExtension, IMultiValueConverter
    {
        public override Object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public Object Convert(Object[] values, Type targetType, Object parameter, CultureInfo culture)
        {
            if (values?.Length >= 3 && values.Length <= 4)
            {
                List<Decimal> decimalValues = new List<Decimal>();

                for (int i = 0; i < values.Length; i++)
                {
                    if (Decimal.TryParse(values[i].ToString(), out Decimal decimalValue))
                    {
                        decimalValues.Add(decimalValue);
                    }
                }

                var alpha = (Byte)255;
                var red = default(Byte);
                var green = default(Byte);
                var blue = default(Byte);

                if (decimalValues.Count == 4)
                {
                    alpha = (byte)Math.Floor(decimalValues[0] >= 1.0m ? 255m : decimalValues[0] * 256.0m);

                    red = (Byte)Math.Round(decimalValues[1]);
                    green = (Byte)Math.Round(decimalValues[2]);
                    blue = (Byte)Math.Round(decimalValues[3]);
                }
                else
                {
                    red = (Byte)Math.Round(decimalValues[0]);
                    green = (Byte)Math.Round(decimalValues[1]);
                    blue = (Byte)Math.Round(decimalValues[2]);
                }


                var systemColor = Color.FromArgb(alpha, red, green, blue);

                return new SolidColorBrush(systemColor);
            }

            return Binding.DoNothing;
        }

        public Object[] ConvertBack(Object value, Type[] targetTypes, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
