using System.Windows;

namespace Balancer.Extensions
{
    public static class DependencyObjectExtensions
    {
        public static Window GetWindow(this DependencyObject dependencyObject)
        {
            if (dependencyObject != default)
            {
                if (dependencyObject is Window window)
                {
                    return window;
                }

                return Window.GetWindow(dependencyObject);
            }

            return default;
        }
    }
}
