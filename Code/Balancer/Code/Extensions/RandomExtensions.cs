using System;

namespace Balancer.Extensions
{
    public static class RandomExtensions
    {
        public static Double NextDoubleRange(this Random random, double minimum, double maximum)
        {
            if (random != default)
            {
                return random.NextDouble() * (maximum - minimum) + minimum;
            }

            return default;
        }

        public static float NextFloatRange(this Random random, float minimum, float maximum)
        {
            if (random != default)
            {
                var randomNumber = random.NextDouble();

                return (float)randomNumber * (maximum - minimum) + minimum;
            }

            return default;
        }
    }
}
