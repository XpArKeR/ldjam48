using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Balancer.Converters
{
    public class BooleanToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public Boolean IsConsumingSpace { get; set; }
        public Boolean IsInvertingValue { get; set; }

        public override Object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            var visiblity = default(Visibility);

            if (value is Boolean booleanValue)
            {
                if (booleanValue)
                {
                    if (IsInvertingValue)
                    {
                        if (IsConsumingSpace)
                        {
                            visiblity = Visibility.Hidden;
                        }
                        else
                        {
                            visiblity = Visibility.Collapsed;
                        }
                    }
                    else
                    {
                        visiblity = Visibility.Visible;
                    }
                }
                else
                {
                    if (IsInvertingValue)
                    {
                        visiblity = Visibility.Visible;
                    }
                    else
                    {
                        if (IsConsumingSpace)
                        {
                            visiblity = Visibility.Hidden;
                        }
                        else
                        {
                            visiblity = Visibility.Collapsed;
                        }
                    }
                }
            }

            return visiblity;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            var isVisible = false;

            if (value is Visibility visibility)
            {
                if (visibility == Visibility.Visible)
                {
                    isVisible = true;
                }
            }

            return isVisible;
        }
    }
}
