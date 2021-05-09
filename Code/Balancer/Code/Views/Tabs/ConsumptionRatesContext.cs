
using Balancer.Model.Core;

namespace Balancer.Views.Tabs
{
    public class ConsumptionRatesContext : TabContext<ConsumptionRates>
    {
        public override void SetContext(ConsumptionRates context)
        {
            base.SetContext(context);

            if (this.Value != default)
            {
                IsEnabled = true;
            }
        }
    }
}
