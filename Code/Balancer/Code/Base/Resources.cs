using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using Balancer.Model.Resources;

namespace Balancer.Base
{
    public static class Resources
    {
        private static ResourceCache resourceCache;
        private static ResourceCache ResourceCache
        {
            get
            {
                return resourceCache;
            }
        }

        public static Resource GetResource(String resourceName)
        {
            return ResourceCache.GetResource(resourceName);
        }

        public static IEnumerable<Resource> GetResources(String resourcePath)
        {
            return ResourceCache.GetResources(resourcePath);
        }
        
        public static IEnumerable<Resource> GetResourcesByName(String resourceName)
        {
            return ResourceCache.GetResourcesByName(resourceName);
        }

        public static async Task LoadAsync(String baseDirectory)
        {
            Debug.WriteLine("Started loading Resources");
            resourceCache = new ResourceCache();

            var resourceDirectoryPath = Path.Combine(baseDirectory, "Assets", "Resources");

            if (Directory.Exists(resourceDirectoryPath))
            {
                await ResourceCache.LoadAsync(resourceDirectoryPath);
            }

            Debug.WriteLine("Finished loading Resources");
        }
    }
}
