using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Balancer.Controls
{
    public partial class DecimalTextBox : TextBox
    {
        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(nameof(MinValue), typeof(Decimal?), typeof(DecimalTextBox));

        public Decimal? MinValue
        {
            get { return (Decimal?)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(nameof(MaxValue), typeof(Decimal?), typeof(DecimalTextBox));

        public Decimal? MaxValue
        {
            get { return (Decimal?)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);

            if (!e.Handled)
            {
                if (e.OriginalSource is TextBox textBox)
                {
                    if (!String.IsNullOrEmpty(textBox.Text))
                    {
                        var value = Decimal.Parse(textBox.Text.Insert(textBox.CaretIndex, e.Text));

                        if (this.MinValue.HasValue)
                        {
                            if (value < this.MinValue.Value)
                            {
                                e.Handled = true;
                            }
                        }

                        if ((!e.Handled) && (this.MaxValue.HasValue))
                        {
                            if (value > this.MaxValue.Value)
                            {
                                e.Handled = true;
                            }
                        }
                    }
                }
            }

            base.OnPreviewTextInput(e);
        }

        bool AreAllValidNumericChars(string str)
        {
            bool ret = true;

            if (str == System.Globalization.NumberFormatInfo.CurrentInfo.NegativeSign | str == System.Globalization.NumberFormatInfo.CurrentInfo.PositiveSign)
            {
                return ret;
            }

            if (str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator)
            {
                return ret;
            }

            int l = str.Length;

            for (int i = 0; i < l; i++)
            {
                char ch = str[i];
                ret &= Char.IsDigit(ch);
            }

            return ret;
        }
    }
}
