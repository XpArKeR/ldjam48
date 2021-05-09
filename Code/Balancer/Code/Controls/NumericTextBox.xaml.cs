using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Balancer.Controls
{
    /// <summary>
    /// Interaction logic for NumericControl.xaml
    /// </summary>
    public partial class NumericTextBox : TextBox
    {
        /// <summary>
        /// Gets or sets the mask to apply to the textbox
        /// </summary>
        public Boolean IsDecimalAllowed
        {
            get { return (Boolean)GetValue(IsDecimalAllowedProperty); }
            set { SetValue(IsDecimalAllowedProperty, value); }
        }

        /// <summary>
        /// Dependency property to store the decimal is allowed to be entered in the textbox
        /// </summary>
        public static readonly DependencyProperty IsDecimalAllowedProperty =
            DependencyProperty.Register(nameof(IsDecimalAllowed), typeof(Boolean), typeof(NumericTextBox), new PropertyMetadata(false));


        /// <summary>
        /// Gets or sets the mask to apply to the textbox
        /// </summary>
        public int Scale
        {
            get { return (int)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }

        /// <summary>
        /// Dependency property to store the decimal is allowed to be entered in the textbox
        /// </summary>
        public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register(nameof(Scale), typeof(int), typeof(NumericTextBox), new PropertyMetadata(0));

        /// <summary>
        /// To check the character enetered
        /// </summary>
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);

            if (!e.Handled)
            {
                e.Handled = !MaxLengthReached(e);
            }

            base.OnPreviewTextInput(e);
        }

        /// <summary>
        ///To check if numbers entered are all valid numeric numbers
        /// </summary>
        bool AreAllValidNumericChars(string str)
        {
            bool ret = true;
            if (str == System.Globalization.NumberFormatInfo.CurrentInfo.NegativeSign |
                str == System.Globalization.NumberFormatInfo.CurrentInfo.PositiveSign)
                return ret;
            if (IsDecimalAllowed && str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator)
                return ret;

            int l = str.Length;
            for (int i = 0; i < l; i++)
            {
                char ch = str[i];
                ret &= Char.IsDigit(ch);
            }

            return ret;
        }

        /// <summary>
        /// This method was added to prevent arithmetic overflows while saving in db on decimal part.
        /// </summary>
        bool MaxLengthReached(TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)e.OriginalSource;
            int precision = textBox.MaxLength - Scale - 2;

            string textToValidate = textBox.Text.Insert(textBox.CaretIndex, e.Text).Replace("-", "");
            string[] numericValues = textToValidate.Split(Convert.ToChar(System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator));

            if ((numericValues.Length <= 2) && (numericValues[0].Length <= precision) && ((numericValues.Length == 1) || (numericValues[1].Length <= Scale)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
