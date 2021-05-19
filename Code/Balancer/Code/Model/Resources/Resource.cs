using System;
using System.Collections.Generic;
using System.Text;

namespace Balancer.Model.Resources
{
    public class Resource
    {
        public String Key { get; set; }
        public Byte[] Content { get; set; }
        public ResourceType ResourceType { get; set; }
        public String Name { get; internal set; }
    }
}
