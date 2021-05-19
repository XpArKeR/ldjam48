using System.Windows;

using Balancer.Extensions;

namespace Balancer.Behaviors
{
    public static class DialogCloser
    {
        public static readonly DependencyProperty DialogResultProperty = DependencyProperty.RegisterAttached("DialogResult", typeof(bool?), typeof(DialogCloser), new PropertyMetadata(DialogResultChanged));
        private static void DialogResultChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var window = dependencyObject.GetWindow();

            if (window != default)
            {
                window.DialogResult = e.NewValue as bool?;
            }
        }

        public static void SetDialogResult(DependencyObject target, bool? value)
        {
            target.SetValue(DialogResultProperty, value);
        }
    }
}
