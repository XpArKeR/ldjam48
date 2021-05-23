using System;

namespace Balancer.Views
{
    public class DialogContext : BaseContext
    {
        private Boolean? dialogResult;
        public Boolean? DialogResult
        {
            get
            {
                return this.dialogResult;
            }
            set
            {
                SetProperty(ref this.dialogResult, value);
            }
        }
    }
}
