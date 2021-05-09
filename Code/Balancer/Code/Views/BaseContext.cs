using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Balancer.Views
{
    public class BaseContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected Boolean SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }
    }
}
