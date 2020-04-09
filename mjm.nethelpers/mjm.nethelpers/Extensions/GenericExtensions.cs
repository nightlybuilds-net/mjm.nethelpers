using System;
using System.Runtime.InteropServices;

namespace mjm.nethelpers.Extensions
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Clamp value be
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static T Clamp<T>(this T value, T min, T max) where T : IComparable
        {
            if(min.CompareTo(max) > 0) throw new Exception("Min must be smaller then max");

            if (value.CompareTo(min) < 0) return min;
            if (value.CompareTo(max) > 0) return max;
            return value;
        }
    }
}