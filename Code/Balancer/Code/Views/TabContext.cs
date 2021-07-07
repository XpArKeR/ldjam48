using System;

namespace Balancer.Views
{
    public class TabContext<T> : BaseContext
    {
        private Boolean isEnabled;
        public Boolean IsEnabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                SetProperty(ref this.isEnabled, value);
            }
        }

        private String basePath;
        public String BasePath
        {
            get
            {
                return this.basePath;
            }
            private set
            {
                SetProperty(ref this.basePath, value);
            }
        }

        private T value;
        public T Value
        {
            get
            {
                return this.value;
            }
            private set
            {
                SetProperty(ref this.value, value);
            }
        }

        public virtual void SetContext(T context)
        {
            this.Value = context;
        }

        public virtual Boolean Load(String baseDirectoryPath)
        {
            this.BasePath = baseDirectoryPath;

            return true;
        }
    }
}
