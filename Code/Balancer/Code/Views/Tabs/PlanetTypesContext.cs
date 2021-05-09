using System.Collections.Generic;

using Balancer.Model.Planets;

namespace Balancer.Views.Tabs
{
    public class PlanetTypesContext : TabContext<List<PlanetType>>
    {
        public override void SetContext(List<PlanetType> context)
        {
            base.SetContext(context);

            if (this.Value?.Count > 0)
            {
                IsEnabled = true;
            }
        }
    }
}
