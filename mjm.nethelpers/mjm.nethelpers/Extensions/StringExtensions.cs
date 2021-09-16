using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;

namespace mjm.nethelpers.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Deserialize JSON to T using System.Text.Json
        /// </summary>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromJson<T>(this string json, JsonSerializerOptions options = null)
        {
            return json == null ? default(T) : JsonSerializer.Deserialize<T>(json, options);
        }

        /// <summary>
        /// Deserialize JSON to T using System.Text.Json
        /// </summary>
        /// <param name="json"></param>
        /// <param name="anonObject"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromJson<T>(this string json, T anonObject, JsonSerializerOptions options = null)
        {
            return json == null ? default(T) : JsonSerializer.Deserialize<T>(json, options);
        }


        /// <summary>
        /// Deserialize JSON to object using System.Text.Json
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object FromJson(this string json, Type type, JsonSerializerOptions options = null)
        {
            return json == null ? default(object) : JsonSerializer.Deserialize(json, type,options);
        } 

        public static T Antani<T>(this string json, Type type, JsonSerializerOptions options = null)
        {
            var theObj = JsonSerializer.Deserialize(json, type);
            return (T) theObj;
        }

        /// <summary>
        /// Extension for string.IsNullOrEmpty
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }
        
        /// <summary>
        /// Extension for string.IsNullOrWhiteSpace
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        /// <summary>
        /// Parse string to T
        /// </summary>
        /// <param name="text"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Parse<T>(this string text)
        {
            return (T)Convert.ChangeType(text, typeof(T));
        }
        
        /// <summary>
        /// try Parse string to T.
        /// Return Default if exception
        /// </summary>
        /// <param name="text"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T TryParse<T>(this string text)
        {
            try
            {
                return (T)Convert.ChangeType(text, typeof(T));

            }
            catch
            {
                return default;
            }
        }

        /// <summary>
        /// Parse string to DateTime.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="cultureInfo"></param>
        /// <param name="dateTimeStyles"></param>
        /// <returns></returns>
        public static DateTime ParseDateTime(this string text, CultureInfo cultureInfo = null,
            DateTimeStyles dateTimeStyles = DateTimeStyles.None) 
        {
            return DateTime.Parse(text, cultureInfo, dateTimeStyles);
        }
        
        /// <summary>
        /// Try parse string to DateTime
        /// </summary>
        /// <param name="text"></param>
        /// <param name="cultureInfo"></param>
        /// <param name="dateTimeStyles"></param>
        /// <returns></returns>
        public static DateTime TryParseDateTime(this string text, CultureInfo cultureInfo = null,
            DateTimeStyles dateTimeStyles = DateTimeStyles.None)
        {
            var parse = DateTime.TryParse(text, cultureInfo, dateTimeStyles, out DateTime result);
            return parse ? result : default(DateTime);
        }
    }
}