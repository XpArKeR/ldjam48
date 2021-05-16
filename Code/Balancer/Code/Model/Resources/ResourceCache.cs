using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Balancer.Model.Resources
{
    public class ResourceCache
    {
        IDictionary<String, Resource> resourceByKeyCache = new Dictionary<String, Resource>();
        IDictionary<String, Resource> resourceByNameCache = new Dictionary<String, Resource>();

        public IList<Resource> GetResources(String resourceName)
        {
            var results = new List<Resource>();



            return results;
        }

        public static Resource GetResource(String resourceKey)
        {
            var resource = default(Resource);

            if (!String.IsNullOrEmpty(resourceKey))
            {

            }

            return resource;
        }

        public async Task LoadAsync(String resourceBaseDirectory)
        {
            await Task.Run(() =>
            {
                foreach (var subDirectory in Directory.EnumerateDirectories(resourceBaseDirectory))
                {
                    LoadResources(subDirectory, resourceBaseDirectory);
                }

                System.Diagnostics.Debug.WriteLine(String.Format("Loaded {0} Resources", this.resourceByKeyCache.Count));
            });
        }

        private void LoadResources(String currentDirectory, String baseDirectory)
        {
            foreach (var file in Directory.EnumerateFiles(currentDirectory))
            {
                var extension = Path.GetExtension(file).ToLower();

                switch (extension)
                {
                    case ".png":
                    case ".jpg":
                    case ".jpeg":
                        var resource = new Resource()
                        {
                            Key = GetResourceKey(file, baseDirectory),
                            Name = Path.GetFileNameWithoutExtension(file),
                            Content = File.ReadAllBytes(file),
                            ResourceType = ResourceType.Image
                        };

                        this.resourceByKeyCache[resource.Key] = resource;
                        this.resourceByNameCache[resource.Name] = resource;
                        break;

                    case ".json":

                        break;
                }
            }

            foreach (var subDirectory in Directory.EnumerateDirectories(currentDirectory))
            {
                LoadResources(subDirectory, baseDirectory);
            }
        }

        private String GetResourceKey(String file, String baseDirectory)
        {
            var path = file.Replace(baseDirectory, "");

            while (path.StartsWith(Path.DirectorySeparatorChar))
            {
                path = path.Substring(1);
            }

            return path;
        }
    }
}
