using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
