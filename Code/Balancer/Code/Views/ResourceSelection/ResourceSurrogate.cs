using System;

using Balancer.Model;
using Balancer.Model.Resources;

namespace Balancer.Views.ResourceSelection
{
    public class ResourceSurrogate : NotifyingObject
    {
        public ResourceSurrogate()
        {

        }

        public ResourceSurrogate(Resource resource)
        {
            this.Resource = resource;
        }

        private Boolean isSelected;
        public Boolean IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                SetProperty(ref this.isSelected, value);
            }
        }

        private Resource resource;
        public Resource Resource
        {
            get
            {
                return this.resource;
            }
            set
            {
                SetProperty(ref this.resource, value);
            }
        }
    }
}
