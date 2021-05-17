using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Balancer.Model.Resources
{
    public class ResourceCache
    {
        IDictionary<String, Resource> resourceByKeyCache = new Dictionary<String, Resource>();
        IDictionary<String, List<Resource>> resourceByNameCache = new Dictionary<String, List<Resource>>();

        public IEnumerable<Resource> GetResources(String resourceName)
        {
            if (resourceByNameCache.TryGetValue(resourceName, out List<Resource> namedResources))
            {
                foreach (var resource in namedResources)
                {
                    yield return resource;
                }
            }

            yield break;
        }

        public Resource GetResource(String resourceKey)
        {
            var resource = default(Resource);

            if ((!String.IsNullOrEmpty(resourceKey)) && (!resourceByKeyCache.TryGetValue(resourceKey, out resource)))
            {
                Debug.WriteLine(String.Format("No resource found for Key '{0}'", resourceKey));
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

                var resource = default(Resource);

                switch (extension)
                {
                    case ".png":
                    case ".jpg":
                    case ".jpeg":
                        resource = new Resource()
                        {
                            Key = GetResourceKey(file, baseDirectory),
                            Name = Path.GetFileNameWithoutExtension(file),
                            Content = File.ReadAllBytes(file),
                            ResourceType = ResourceType.Image
                        };

                        break;

                    case ".json":

                        break;
                }

                if (resource != default)
                {
                    this.resourceByKeyCache[resource.Key] = resource;

                    if (!resourceByNameCache.TryGetValue(resource.Name, out List<Resource> namedResources))
                    {
                        namedResources = new List<Resource>();
                        this.resourceByNameCache[resource.Name] = namedResources;
                    }

                    namedResources.Add(resource);
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
