using System;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


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
        public static T To<T>(this object obj)
        {
            return (T) obj;
        }
        
        /// <summary>
        /// Cast to T. Return default if cannot cast
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SafelyTo<T>(this object obj) where T : class
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


        /// <summary>
        /// Concatenate all public properties
        /// Propertyname: value -- Properyname: value
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string PropertiesToString(this object obj)
        {
            if (obj == null) return "[NULL]";

            var builder = new StringBuilder();
            var properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var propertyInfo in properties)
            {
                builder.Append($"{propertyInfo.Name}: {propertyInfo.GetValue(obj)} -- ");
            }

            var res = builder.ToString();
            return res.Substring(0,res.Length - 4);
        }


        /// <summary>
        /// Serialize object to JSON using System.Text.Json
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string ToJson(this object obj, JsonSerializerOptions options = null)
        {
            return obj == null ? null : JsonSerializer.Serialize(obj,options);
        }


        /// <summary>
        /// Get IReflectionActions helper
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IReflectionActions ByReflection(this object obj)
        {
            return new ReflectionHelper(obj);
        }
        
        /// <summary>
        /// Check if object is disposed catching ObjectDisposedException
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsDisposed(this object obj)
        {
            try
            {
                var _ = obj.GetHashCode();
                return false;
            }
            catch (ObjectDisposedException)
            {
                return true;
            }
        }
        
        /// <summary>
        /// Run action if condition is true
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="condition"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        public static void If<T>(this T obj,Func<T,bool> condition, Action action)
        {
            if (condition.Invoke(obj))
                action();
        }
        
        /// <summary>
        /// Run task if condition is true
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="condition"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        public static Task If<T>(this T obj,Func<T,bool> condition, Func<Task> action)
        {
            return condition.Invoke(obj) ? action() : Task.CompletedTask;
        }

    }

}