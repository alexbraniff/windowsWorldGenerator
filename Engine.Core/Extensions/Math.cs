using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Extensions
{
    public static class Math
    {
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        public static float Spread(this float input, float inputStart, float inputEnd, float outputStart, float outputEnd)
        {
            float slope = 1.0f * (outputEnd - outputStart) / (inputEnd - inputStart);

            return (outputStart + slope * (input - inputStart));
        }
    }
}
