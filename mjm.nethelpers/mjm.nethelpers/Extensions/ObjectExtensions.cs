using System;

namespace mjm.nethelpers.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// True if object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }
        
        /// <summary>
        /// True if object is not null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        /// <summary>
        /// True if obj type is typeof t
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Is<T>(this object obj)
        {
            return obj is T;
        }

        /// <summary>
        /// Cast to T
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Cast<T>(this object obj)
        {
            return (T) obj;
        }
        
        /// <summary>
        /// Cast to T. Return default if cannot cast
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafelyCast<T>(this object obj) where T : class
        {
            try
            {
                return (T) obj;
            }
            catch
            {
                return default(T);
            }
        }
    }

}