using System.Collections.Generic;

using Balancer.Model.Ships;

namespace Balancer.Views.Tabs
{
    public class ShipTypesContext : TabContext<List<ShipType>>
    {
        public override void SetContext(List<ShipType> context)
        {
            base.SetContext(context);

            if (this.Value?.Count > 0)
            {
                IsEnabled = true;
            }
        }
    }
}
