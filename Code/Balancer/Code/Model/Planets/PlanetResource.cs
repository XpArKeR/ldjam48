
using Newtonsoft.Json;

namespace Balancer.Model.Planets
{
    public class PlanetResource
    {
        [JsonIgnore]
        public float Value { get; set; }
        public float RangeMin { get; set; }
        public float RangeMax { get; set; }
        public float Dispersion { get; set; }
        [JsonIgnore]
        public float DispersionRangeMin { get; set; }
        [JsonIgnore]
        public float DispersionRangeMax { get; set; }
    }
}
