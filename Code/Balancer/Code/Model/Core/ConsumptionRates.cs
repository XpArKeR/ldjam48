using System;
using System.Collections.Generic;
using System.Text;

namespace Balancer.Model.Core
{
    public class ConsumptionRates
    {
        public Double Scan { get; set; }
        public Double Movement { get; set; }
        public Double GatherOxygen { get; set; }
        public Double GatherFood { get; set; }
        public Double GatherFuel { get; set; }
    }
}
