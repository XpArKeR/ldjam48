using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Balancer.Model.Resources;

namespace Balancer.Views.ResourceSelection
{
    public class ResourceSurrogate : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        protected Boolean SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = default)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        protected void OnPropertyChanged(String propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
