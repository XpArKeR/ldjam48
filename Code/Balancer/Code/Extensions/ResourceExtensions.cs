using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Balancer.Model.Resources;

namespace Balancer.Extensions
{
    public static class ResourceExtensions
    {
        public static ImageSource ToImageSource(this Resource resource)
        {
            if ((resource?.ResourceType == ResourceType.Image) && (resource.Content != default))
            {
                var imageSource = new BitmapImage();

                var memoryStream = new MemoryStream(resource.Content);

                imageSource.BeginInit();
                imageSource.StreamSource = memoryStream;
                imageSource.EndInit();

                return imageSource;
            }

            return default;
        }
    }
}
