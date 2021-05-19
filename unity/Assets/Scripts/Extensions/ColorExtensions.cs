
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class ColorExtensions
    {
        public static void Normalize(this Color color)
        {
            if (color != default)
            {
                if (color.a > 1)
                {
                    color.a /= 255;
                }

                if (color.r > 1)
                {
                    color.r /= 255;
                }

                if (color.g > 1)
                {
                    color.g /= 255;
                }

                if (color.b > 1)
                {
                    color.b /= 255;
                }
            }
        }
    }
}
