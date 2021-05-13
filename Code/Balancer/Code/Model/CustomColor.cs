using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Balancer.Model
{
    public class CustomColor : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CustomColor()
        {

        }

        public CustomColor(float a, float r, float g, float b)
        {
            this.A = a;
            this.R = r;
            this.G = g;
            this.B = b;
        }

        private float a;
        public float A
        {
            get
            {
                return this.a;
            }
            set
            {
                SetProperty(ref this.a, value);
            }
        }

        private float r;
        public float R
        {
            get
            {
                return this.r;
            }
            set
            {
                SetProperty(ref this.r, value);
            }
        }

        private float g;
        public float G
        {
            get
            {
                return this.g;
            }
            set
            {
                SetProperty(ref this.g, value);
            }
        }

        private float b;
        public float B
        {
            get
            {
                return this.b;
            }
            set
            {
                SetProperty(ref this.b, value);
            }
        }

        protected Boolean SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
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
