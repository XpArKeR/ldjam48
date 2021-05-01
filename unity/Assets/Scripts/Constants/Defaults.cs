using System;

namespace Assets.Scripts.Constants
{
    public static class Defaults
    {
        private const String consumptionRatesString = @"{
  ""scan"": 0.05,
  ""movement"": 1.0,
  ""gatherOxygen"": 0.1,
  ""gatherFood"": 0.1,
  ""gatherFuel"": 0.1
}";

        private static ConsumptionRates consumptionRates;
        public static ConsumptionRates ConsumptionRates
        {
            get
            {
                if (consumptionRates == default)
                {
                    consumptionRates = UnityEngine.JsonUtility.FromJson<ConsumptionRates>(consumptionRatesString);
                }

                return consumptionRates;
            }
        }

    }
}
