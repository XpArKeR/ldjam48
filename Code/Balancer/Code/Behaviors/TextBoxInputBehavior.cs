using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Balancer.Behaviors
{
    public class TextBoxInputBehavior : Behavior<TextBox>
    {
        const NumberStyles validNumberStyles = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign;

        public TextBoxInputBehavior()
        {
            this.InputMode = TextBoxInputMode.None;
            this.JustPositivDecimalInput = false;
        }

        public TextBoxInputMode InputMode { get; set; }

        public static readonly DependencyProperty JustPositivDecimalInputProperty = DependencyProperty.Register(nameof(JustPositivDecimalInput), typeof(bool), typeof(TextBoxInputBehavior), new FrameworkPropertyMetadata(false));

        public bool JustPositivDecimalInput
        {
            get { return (bool)GetValue(JustPositivDecimalInputProperty); }
            set { SetValue(JustPositivDecimalInputProperty, value); }
        }

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(nameof(MinValue), typeof(Decimal?), typeof(TextBoxInputBehavior));

        public Decimal? MinValue
        {
            get { return (Decimal?)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(nameof(MaxValue), typeof(Decimal?), typeof(TextBoxInputBehavior));

        public Decimal? MaxValue
        {
            get { return (Decimal?)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewTextInput += AssociatedObjectPreviewTextInput;
            AssociatedObject.PreviewKeyDown += AssociatedObjectPreviewKeyDown;

            DataObject.AddPastingHandler(AssociatedObject, Pasting);

        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewTextInput -= AssociatedObjectPreviewTextInput;
            AssociatedObject.PreviewKeyDown -= AssociatedObjectPreviewKeyDown;

            DataObject.RemovePastingHandler(AssociatedObject, Pasting);
        }

        private void Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                var pastedText = (String)e.DataObject.GetData(typeof(String));

                if (!this.IsValidInput(this.GetText(pastedText)))
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.CancelCommand();
                }
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
                e.CancelCommand();
            }
        }

        private void AssociatedObjectPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                if (!this.IsValidInput(this.GetText(" ")))
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                }
            }
        }

        private void AssociatedObjectPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!this.IsValidInput(this.GetText(e.Text)))
            {
                System.Media.SystemSounds.Beep.Play();
                e.Handled = true;
            }
        }

        private string GetText(string input)
        {
            var txt = this.AssociatedObject;

            int selectionStart = txt.SelectionStart;

            if (txt.Text.Length < selectionStart)
            {
                selectionStart = txt.Text.Length;
            }

            int selectionLength = txt.SelectionLength;

            if (txt.Text.Length < selectionStart + selectionLength)
            {
                selectionLength = txt.Text.Length - selectionStart;
            }

            var realtext = txt.Text.Remove(selectionStart, selectionLength);

            int caretIndex = txt.CaretIndex;

            if (realtext.Length < caretIndex)
            {
                caretIndex = realtext.Length;
            }

            var newtext = realtext.Insert(caretIndex, input);

            return newtext;
        }

        private bool IsValidInput(string input)
        {
            switch (InputMode)
            {
                case TextBoxInputMode.None:
                    return true;

                case TextBoxInputMode.DigitInput:
                    return CheckIsDigit(input);

                case TextBoxInputMode.DecimalInput:

                    if (input.Count(c => c.ToString() == NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator) > 1)
                    {
                        return false;
                    }

                    if (input.Contains(NumberFormatInfo.CurrentInfo.NegativeSign))
                    {
                        if (this.JustPositivDecimalInput)
                        {
                            return false;
                        }

                        if (input.IndexOf(NumberFormatInfo.CurrentInfo.NegativeSign, StringComparison.Ordinal) > 0)
                        {
                            return false;
                        }

                        if (input.Count(x => x.ToString() == NumberFormatInfo.CurrentInfo.NegativeSign) > 1)
                        {
                            return false;
                        }

                        if (input.Length == 1)
                        {
                            return true;
                        }
                    }

                    if (Decimal.TryParse(input, validNumberStyles, CultureInfo.CurrentCulture, out Decimal value))
                    {
                        if (this.MinValue.HasValue)
                        {
                            if (value < this.MinValue.Value)
                            {
                                return false;
                            }
                        }

                        if (this.MaxValue.HasValue)
                        {
                            if (value > this.MaxValue.Value)
                            {
                                return false;
                            }
                        }

                        return true;
                    }

                    break;

                default: throw new ArgumentException("Unknown TextBoxInputMode");
            }

            return false;
        }

        private bool CheckIsDigit(string value)
        {
            return value.All(Char.IsDigit);
        }
    }

    public enum TextBoxInputMode
    {
        None,
        DecimalInput,
        DigitInput
    }
}
